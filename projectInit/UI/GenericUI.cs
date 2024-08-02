using Spectre.Console;

namespace projectInit;

public class GenericUi{

  public static string ask(string text){
    return AnsiConsole.Prompt(
      new TextPrompt<string>($"[blue]{text}: [/]")
    );
  }

  public static bool boolMenu(string text){
    if (!AnsiConsole.Confirm($"[green]{text}[/]")){
    AnsiConsole.MarkupLine("Ok... :(");
    return false;
    }
    return true;
  }
}
