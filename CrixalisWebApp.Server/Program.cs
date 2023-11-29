using CrixalisWebApp.Server.Components;
using Pantheon.Shared.Utility;
using System.Reflection;
using static Pantheon.Shared.Utility.modBaseExtensions;
using static Pantheon.Client.Utility.modVariabel;
using static Pantheon.Server.Utility.modExtensions;
using DevExpress.Blazor;
using Radzen;
using Blazored.Toast;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using Pantheon.Client.Services;
using Pantheon.Client.Services.DataOption;
using Pantheon.Client.Services.Filter;
using Pantheon.Client.Services.LogUser;
using Pantheon.Client.Services.Tag;
using Pantheon.Client.Utility;
using Pantheon.Services;
using bwaCrixalis.Client._1._Master;
using Pantheon.Server.Utility;
using DevExpress.XtraExport.Implementation;
using bwaCrixalis.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Pantheon.Server.DataAccess;
using Pantheon.Server.BackgroundServices;
using bwaCrixalis.Shared._1._Master;
using bwaCrixalis.Server._1._Master;

var builder = WebApplication.CreateBuilder(args);
AssemblyProject = Assembly.GetExecutingAssembly();
IdCompany = "ABC";
//Aplikasi_NamaProduk = "Crixalis";
//appLanguage = "Bahasa";

//builder.UseBlazorPantheon();
builder.Services.AddScoped<pthSvcDataOption>();
builder.Services.AddScoped<pthSvcFilter>();
builder.Services.AddScoped<pthSvcForm>();
builder.Services.AddScoped<pthSvcKonfigurasiHakAkses>();
builder.Services.AddScoped<pthSvcLanguage>();
builder.Services.AddScoped<pthSvcLog>();
builder.Services.AddScoped<pthSvcLogin>();
builder.Services.AddScoped<pthSvcPembayaran>();
builder.Services.AddScoped<pthSvcSettingCompany>();
builder.Services.AddScoped<pthSvcSettingSystem>();
builder.Services.AddScoped<pthSvcSettingUser>();
builder.Services.AddScoped<pthSvcTag>();
builder.Services.AddScoped<pthSvcRekening>();

builder.Services.AddScoped<Pantheon.Client.Utility.ClsServisSignalR>();
builder.Services.AddScoped<PthRcpSetErrorLog>();
builder.Services.AddScoped<pthCalendarService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<DxWindow>();
builder.Services.AddBlazoredToast();
builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = BootstrapVersion.v5);
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton(ConfigMapster());
builder.Services.AddSerialization();

builder.Services.AddHotKeys2();


builder.Services.AddSingleton<svcKaryawan>();
builder.Services.AddSingleton<svcSupplierInstansi>();


// Add builder.Services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<pthServerLoggerInterceptor>();
});
var allow = "AllowAll";
builder.Services.AddCors(o => o.AddPolicy(allow, builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding", "X-Grpc-Web", "User-Agent");
}));

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Pantheon.Server.Utility.modExtensions.NamaDatabase = (conn?.Split(';').FirstOrDefault(x => x.Contains("Database")) ?? conn?.Split(';').FirstOrDefault(x => x.Contains("Initial Catalog")))?.ToString().Split('=')[1].Replace(" ", "");
//Config Database
builder.Services.AddDbContext<CrixalisDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<CrixalisDbContext_Log>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection_Log")));
ConfigurationManager configuration = builder.Configuration;
var appSettingSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();
var key = Encoding.UTF8.GetBytes(appSettings.Secret);

//Add JWT Bearer
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
new Microsoft.OpenApi.Models.OpenApiInfo { Title = "gRPC for Crixalis", Version = "v1" });
});
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

//Svd Pantheon
builder.Services.AddScoped<pthIUnitOfWork, pthUnitOfWork<CrixalisDbContext>>();
builder.Services.AddPantheonDefaultService<CrixalisDbContext, CrixalisDbContext_Log>();

//Log
builder.Services.AddScoped<pthIUnitOfWork_Log, pthUnitOfWork_Log<CrixalisDbContext_Log>>();

//Svd Crixalis
builder.Services.AddScoped<ISvdCompany, svdCompany>();
builder.Services.AddScoped<ISvdKaryawan, svdKaryawan>();

builder.Services
    .AddHostedService<pthBaseStreamBackgroundService<pthT0Jabatan, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil>>()
    .AddHostedService<pthBaseStreamBackgroundService<T0DivisiBarang, T1SubDivisiBarang, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil>>()
    .AddHostedService<pthBaseStreamBackgroundService<T1Supplier, T2AlamatSupplier, T2PenyeliaSupplier, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil>>()
    .AddHostedService<pthBaseStreamBackgroundService<T1Armada, T4NopolArmada, T5ArmadaCustomer, T5ArmadaSopir, BaseModelMasterDetil, BaseModelMasterDetil>>()
    .AddRedis(builder.Configuration.GetConnectionString("RedisCacheConnection"))
    .AddRedisStreaming()
    .AddSerialization()
    .AddStreaming()
    .AddMessaging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var handler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
ClientChannel = GrpcChannel.ForAddress("https://localhost:7236", new GrpcChannelOptions
{
    HttpClient = new HttpClient(handler),
    MaxReceiveMessageSize = 16 * 1024 * 1024
});


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseGrpcWeb();
app.UseCors(allow);
app.MapGrpcReflectionService();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC for Crixalis");
});

app.UsePantheonDefaultService();

//Svs Master
app.MapGrpcService<svsKaryawan>().EnableGrpcWeb();
app.MapGrpcService<svsSupplier>().EnableGrpcWeb();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
