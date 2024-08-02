using Spectre.Console;

namespace projectInit.projectGem;

public class DDDProjectGem
{

    public static async Task run(Project project)
    {
        await AnsiConsole.Status()
          .Spinner(Spinner.Known.Arc)
          .SpinnerStyle(Style.Parse("blue bold"))
          .StartAsync("[blue]Creating the project[/]", async ctx =>
          {

              ctx.Status($"[blue]Started building {project.name}[/]");

              await GenericGemProcess.defaultEstruc(project.name);

              //await GenericGemProcess.Exec("bash",$"mkdir {project.name}/src");
              Directory.CreateDirectory($"{project.name}/src");

              DirectoryInfo directory = new DirectoryInfo(project.name);

              directory.CreateSubdirectory("src");

              AnsiConsole.MarkupLine("[green]Generating DDD Layers[/]");
              await GenericGemProcess.Exec("dotnet", $"new classlib -o {project.name}/src/Domain");
              await GenericGemProcess.Exec("dotnet", $"new classlib -o {project.name}/src/Infrastruture");
              await GenericGemProcess.Exec("dotnet", $"new web -o {project.name}/src/Application");
              AnsiConsole.MarkupLine("[green]Layers Generated[/]");
              // -- necessario? --
              //await GenericGemProcess.Exec("dotnet",$"new classlib -o { project.name }/src/Domain");

              AnsiConsole.MarkupLine("[green]Creating the solution[/]");

              await GenericGemProcess.Exec("dotnet", $"sln {project.name}/{project.name}.sln add {project.name}/src/Domain");
              await GenericGemProcess.Exec("dotnet", $"sln {project.name}/{project.name}.sln add {project.name}/src/Application");
              await GenericGemProcess.Exec("dotnet", $"sln {project.name}/{project.name}.sln add {project.name}/src/Infrastruture");
              AnsiConsole.MarkupLine("[green]Projects added to the solution[/]");

              Messages.Success(project);
          });
    }
}
