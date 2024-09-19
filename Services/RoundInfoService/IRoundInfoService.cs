namespace OwnedGame.Services.RoundInfoService
{
    public interface IRoundInfoService
    {
        public Task<RoundInfoModel> LoadRoundFromJsonAsync(string path);

        public Task WriteRoundToJsonAsync(RoundInfoModel roundInfoModel, string path);
    }
}
