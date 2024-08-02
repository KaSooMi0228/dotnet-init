using CliWrap;
using Spectre.Console;

namespace projectInit.projectGem;

public class GenericProject
{

    public async static Task newProject(Project project)
    {
        await AnsiConsole.Status()
          .Spinner(Spinner.Known.Dots2)
          .SpinnerStyle(Style.Parse("blue bold"))
          .StartAsync("[blue]Creating the project[/]", async ctx =>
          {

              ctx.Status("[blue]Generating Folders...[/]");

              await GenericGemProcess.defaultEstruc(project.name);
              AnsiConsole.MarkupLine("[green]Folders Generated[/]");

              ctx.Status("[blue]Generating project[/]");

              if (project.lang == "F#")
                  await GenericGemProcess.Exec("dotnet", $"new {project.type} -lang f# -o {project.name}/{project.name}");
              else
                  await GenericGemProcess.Exec("dotnet", $"new {project.type} -o {project.name}/{project.name}");

              AnsiConsole.MarkupLine("[green].Net Project Generated[/]");

              await GenericGemProcess.Exec("dotnet", $"sln {project.name}/{project.name}.sln add {project.name}/{project.name}");
              AnsiConsole.MarkupLine("[green]Solution Generated[/]");

              AnsiConsole.MarkupLine("[green]Project Generated[/]");
          });

        var rule = new Rule();
        AnsiConsole.Write(rule);


        Messages.Success(project);
    }
}
