using Spectre.Console;

public class Menus
{

    public static string show(string[] choices)
      => AnsiConsole.Prompt(
        new SelectionPrompt<string>()
          .Title("Select the [green]Project Type[/]")
          .MoreChoicesText("[gree] Move up and down to reveal more fruits [/]")
          .AddChoices(choices)
      );

    public static string[] showMulti(string[] choices)
      => AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
          .Title("Select the packages that you want for the project?")
          .NotRequired()
          .MoreChoicesText("")
          .AddChoices(choices)
      ).ToArray();
}
