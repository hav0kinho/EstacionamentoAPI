using EstacionamentoAPI.Services;
using EstacionamentoAPI;
using EstacionamentoAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("EstacionamentoDataManagement");
});

// Configurando JWT

var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Em geral, est� sendo configurado o processo/passos que deve ser feito na autentica��o! Nesse caso o Bearer � para verificar a toda requisi��o o Token, no Header da requisi��o!
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Aqui � configurado o processo/passos que devem ser feitos caso o usu�rio n�o esteja autenticado!
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false; // N�o precisa ser HTTPS
    x.SaveToken = true; // Deve salvar o Token (Aonde, n�o sei)
    x.TokenValidationParameters = new TokenValidationParameters // Quais valida��es ser�o feitas
    {
        ValidateIssuerSigningKey = true, // Deve validar a assinatura do Token
        IssuerSigningKey = new SymmetricSecurityKey(key), // Qual chave ele vai usar para validar
        ValidateIssuer = false, // Esse e o Audience s�o mais complexos e n�o v�o ser usados, caem mais na parte de oAuth e etc e est� relacionadno ao DefaultChallengeScheme
        ValidateAudience = false
    };
});

builder.Services.AddTransient<TokenService>(); // Adicionando serviço para injeção de dependência

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
