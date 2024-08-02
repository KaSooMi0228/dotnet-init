using projectInit.projectGem;
using Spectre.Console;

namespace projectInit;

public class FriendlyMode
{
    private static string[] projectTypes = { "Create a Project", "Add a packcage", "remove a package" };
    private static string[] langs = { "C#", "F#" };

    public async static Task handle()
    {
        Messages.showTitle(".Net Initializer");

        var rule = new Rule();
        AnsiConsole.Write(rule);

        Project project = new Project();

        Dictionary<string, string> projectOptions = new Dictionary<string, string>();

        projectOptions.Add("Terminal based App [yellow](console)[/]", "console");
        projectOptions.Add("Blank Web Api [yellow](web)[/]", "web");
        projectOptions.Add("Web Api with Controller [yellow](webapi)[/]", "webapi");
        projectOptions.Add("Blazor Client [yellow](blazorwasm)[/]", "blazorwasm");
        projectOptions.Add("Blazor Client Empty [yellow](blazorwasm-empty)[/]", "blazorwasm-empty");
        projectOptions.Add("Blazor web server [yellow](blazorserver)[/]", "blazorserver");
        projectOptions.Add("Blazor web server Empty[yellow](blazorserver-empty)[/]", "blazorserver-empty");
        projectOptions.Add("WebApplication [yellow](webapp/razor)[/]", "webapp");
        projectOptions.Add("MVC WebApplication [yellow](mvc)[/]", "mvc");
        projectOptions.Add("An Api with DDD architecture [yellow](DDD)[/]", "DDD");

        string[] choices = projectOptions.Keys.ToArray();

        project.type = projectOptions[Menus.show(choices)];
        project.name = GenericUi.ask("Project name");

        project.lang = Menus.show(langs);
        // libs

        if (project.type == "DDD")
            await DDDProjectGem.run(project);
        else
            await GenericProject.newProject(project);
    }
}
