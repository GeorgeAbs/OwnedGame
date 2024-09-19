namespace OwnedGame.Services.RoundInfoService
{
    public class RoundInfoModel 
    {
        public List<string> Competitors { get;  set; } = ["User1", "User2","User3","User4", "User5"];
        public int RowsHeight { get; private set; } = 162;
        public ColorModel NotClickedCellsColor { get;  set; } = new ColorModel(0, 0, 170);

        public ColorModel ClickedCellsColor { get;  set; } = new ColorModel(50, 50, 200);

        public RoundInfoRow Row0 { get;  set; } = new();

        public RoundInfoRow Row1 { get;  set; } = new();

        public RoundInfoRow Row2 { get;  set; } = new();

        public RoundInfoRow Row3 { get;  set; } = new();

        public RoundInfoRow Row4 { get;  set; } = new();

        public RoundInfoRow Row5 { get;  set; } = new();
    }

    public class RoundInfoRow 
    {
        public bool IsEnable { get; set; } = false;

        public string Topic { get; set; } = "ООООЧЕНЬ ОЧЕНЬ ОЧЕНЬ ДЛИННЫЙ топик";

        public RoundInfoCell Cell1 { get; set; } = new() { Price = "100", Type = RoundInfoCellType.DogInBag, Picture1 = "C:/Users/Asus/Pictures/ZoomIn.png" };
        public RoundInfoCell Cell2 { get; set; } = new() { Price = "200", Type = RoundInfoCellType.Meme, Picture1 = "C:/Users/Asus/Pictures/ZoomIn.png", Picture2 = "C:/Users/Asus/Pictures/banner.png" };
        public RoundInfoCell Cell3 { get; set; } = new() { Price = "300" };
        public RoundInfoCell Cell4 { get; set; } = new() { Price = "400" };
        public RoundInfoCell Cell5 { get; set; } = new() { Price = "500" };
        public RoundInfoCell Cell6 { get; set; } = new() { Price = "1000" };
        public RoundInfoCell Cell7 { get; set; } = new() { Price = "1500" };
    }

    public class RoundInfoCell
    {
        public RoundInfoCellType Type { get; set; }

        public bool IsEnable { get; set; } = false;

        public string? Question { get; set; } = "ВОПРОСССС";

        public string Price { get; set; } = string.Empty;

        public string? Picture1 { get; set; }

        public string? Picture2 { get; set; }
    }

    public enum RoundInfoCellType
    {
        SimpleQuestion,
        DogInBag,
        Meme
    }
}
