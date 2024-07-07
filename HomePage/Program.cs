using HomePage.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;


try
{
    // check if the defaults directory exists (it should)
    if (Directory.Exists("wwwroot/defaults"))
    {
        // get a list of files from the defaults directory
        var files = Directory.GetFiles("wwwroot/defaults");
        
        // check if the images directory exists (it may not)
        if (!Directory.Exists("wwwroot/images"))
            // create the directory if it does not
            Directory.CreateDirectory("wwwroot/images");

        // loop through all the files found in the defaults directory
        foreach (var file in files)
        {
            // calculate the filename in the images directory
            string newFile = $"wwwroot/images/{Path.GetFileName(file)}";
            // if the file does not exist in the images directory
            if (!File.Exists(newFile))
                // copy it over to the images directory
                File.Copy(file, newFile);
        }
    }
}
catch (Exception) { }

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<SettingsService>();

builder.Services.AddHttpClient();
builder.Services.AddFluentUIComponents(options =>
{
    options.ValidateClassNames = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
