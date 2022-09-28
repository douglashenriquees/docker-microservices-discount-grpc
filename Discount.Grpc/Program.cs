using Discount.Grpc.Repositories;
using Discount.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<DiscountService>();

app.Run();