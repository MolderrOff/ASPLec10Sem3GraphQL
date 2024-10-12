using ASPLec10Sem3GraphQL.Abstraction;
using ASPLec10Sem3GraphQL.Data;
using ASPLec10Sem3GraphQL.Graph.Mutation;
using ASPLec10Sem3GraphQL.Graph.Query;
using ASPLec10Sem3GraphQL.Mapper;
using ASPLec10Sem3GraphQL.Repository;
using Microsoft.EntityFrameworkCore;

//1. ���������� Qery �������� ��������� � �����


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(); 
//var context = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<StorageContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("db")));//----������� ����� ������
builder.Services.AddScoped<IProductRepository, ProductRepository>(); //AddScoped  AddSingleton
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();//AddScoped  AddSingleton
builder.Services.AddScoped<IStorageRepository, StorageRepository>();//������� ��� ��
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();//��������//---I    AddSingleton<ProductGroupRepository>().
builder.Services.AddMemoryCache();//��������

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.MapGraphQL();
app.Run();
