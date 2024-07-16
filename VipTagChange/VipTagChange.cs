using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;

namespace VipTagChange;

public class VipTagChange : BasePlugin
{
    public override string ModuleName => "VipTagChange plugin";
    public override string ModuleVersion => "0.0.1";

    public override string ModuleDescription => "Ability for VIP Players to change their scoreboard and chat tag";
    public override string ModuleAuthor => "Letaryat";

    public override void Load(bool hotReload){
        Console.WriteLine("Hi!");
    }

    [ConsoleCommand("css_tag", "Ability for VIP to change their Scoreboard and Chat tag")]
    [RequiresPermissions("@vip-plugin/vip")]
    public void TagChange(CCSPlayerController? player, CommandInfo commandInfo){
        var tag = commandInfo.GetArg(1);
        player!.Clan = tag;
        Utilities.SetStateChanged(player, "CCSPlayerController", "m_szClan");
        Server.PrintToChatAll("Graczowi: " + player + "Ustawiono: " + tag);
    }

}
