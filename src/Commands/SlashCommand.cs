using Discord;
using Discord.WebSocket;

namespace SharpCmds.Commands;

public abstract class SlashCommand
{
    protected string Description { get; init; } = "";

    protected readonly SlashCommandBuilder Cmd = new SlashCommandBuilder();
    public readonly List<String> Ids = new List<string>();

    public SlashCommandBuilder Build()
    {
        Cmd.WithName(GetType().Name.ToLower());
        Cmd.WithDescription(Description);
        
        return Cmd;
    }

    protected string CustomId(String id)
    {
        var clsName = GetType().Name.ToLower();
        
        if (!Ids.Contains($"{clsName}_{id}"))
        {
            Ids.Add($"{clsName}_{id}");
        }
        return $"{clsName}_{id}";
    }

    public abstract Task Run(SocketSlashCommand command);

    public virtual Task OnComponent(SocketMessageComponent component)
    {
        return Task.CompletedTask;
    }
    
    public virtual Task OnComponent(SocketModal component)
    {
        return Task.CompletedTask;
    }
}