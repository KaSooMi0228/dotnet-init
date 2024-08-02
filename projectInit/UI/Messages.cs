using Spectre.Console;

namespace projectInit;

public class Messages
{

    public static void showTitle(string title)
      => AnsiConsole.Write(
          new FigletText(title)
          .Centered());

    public static void Success(Project project)
    => AnsiConsole.Markup($"Your {project.type} [blue]{project.name}[/] was created \n");

}
