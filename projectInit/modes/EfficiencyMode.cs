using projectInit.projectGem;

namespace projectInit;

public class EfficiencyMode
{

    private static string[] options { get; set; } = { "help" };

    public async static Task handle(string[] args)
    {

        /* - tipo []
         * - nome []
         * - package[]
        */

        bool op = (args[0] == "" || args[1] == "")
          ? true
          : false;

        if (op)
            Environment.Exit(0);

        Project project = new Project()
        {
            name = args[0],
            type = args[1],
        };
    }

}
