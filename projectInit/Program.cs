using projectInit;

Console.Clear();

if(args.Length<=0)
  await FriendlyMode.handle();
else
  await EfficiencyMode.handle(args);
