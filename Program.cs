var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddCors(options => {
//    options.AddPolicy("AllowAll", policy => {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
//app.UseCors("AllowAll");
//app.UseAuthentication();
app.UseAuthorization();
//加上这句话之后，所有的not found以及 Err错误就消失了
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.MapRazorPages();

app.Run();
