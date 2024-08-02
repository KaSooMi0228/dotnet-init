using CliWrap;

namespace projectInit.projectGem;

public class GenericGemProcess
{

    public static async Task defaultEstruc(string name)
    {

        Directory.CreateDirectory(name);

        await Exec("dotnet", $"new sln -o {name}");

        await Exec("dotnet", $"new gitignore -o {name}");
    }

    public async static Task Exec(string program, string args)
      => await Cli.Wrap(program)
        .WithArguments(args)
        .ExecuteAsync();

    //public async static Task AddTests(Project project){}

}
