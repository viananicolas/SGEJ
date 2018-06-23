using System.ComponentModel.DataAnnotations;

namespace SGEJ.Models.Enums
{
    public enum Plataforma
    {
        [Display(Name = "Sony PlayStation")]

        PlayStation1 = 0,
        [Display(Name = "Sony PlayStation 2")]

        PlayStation2 = 1,
        [Display(Name = "Sony PlayStation 3")]

        PlayStation3 = 2,
        [Display(Name = "Sony PlayStation 4")]

        PlayStation4 = 3,
        [Display(Name = "Sony PlayStation Portable")]

        PlayStationPortable = 4,
        [Display(Name = "Sony PlayStation Vita")]

        PlayStationVita = 5,
        [Display(Name = "Microsoft Xbox")]

        Xbox = 6,
        [Display(Name = "Microsoft Xbox 360")]

        Xbox360 = 7,
        [Display(Name = "Microsoft Xbox One")]

        XboxOne = 8,
        [Display(Name = "NES")]

        NES = 9,
        [Display(Name = "Super NES")]

        SNES = 10,
        [Display(Name = "Nintendo 64")]

        Nintendo64 = 11,
        [Display(Name = "Nintendo GameCubbe")]

        NintendoGameCube = 12,
        [Display(Name = "Nintendo Wii")]

        NintendoWii = 13,
        [Display(Name = "Nintendo WiiU")]

        NintendoWiiU = 14,
        [Display(Name = "Nintendo Switch")]

        NintendoSwitch = 15,
        [Display(Name = "Nintendo Game & Watch")]

        NintendoGameAndWatch = 16,
        [Display(Name = "Nintendo Game Boy")]

        NintendoGameBoy = 17,
        [Display(Name = "Nintendo Game Boy Color")]

        NintendoGameBoyColor = 18,
        [Display(Name = "Nintendo Game Boy Advance")]

        NintendoGameBoyAdvance = 19,
        [Display(Name = "Nintendo DS")]

        NintendoDS = 20,
        [Display(Name = "Nintendo 3DS")]

        Nintendo3DS = 21,
        [Display(Name = "Sega Master System")]

        SegaMasterSystem = 22,
        [Display(Name = "Sega Mega Drive")]

        SegaMegaDrive = 23,
        [Display(Name = "Sega Saturn")]

        SegaSaturn = 24,
        [Display(Name = "Sega Dreamcast")]

        SegaDreamcast = 25,
        [Display(Name = "PC")]

        PC = 26,
    }
}