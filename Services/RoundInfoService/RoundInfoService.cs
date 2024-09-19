using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace OwnedGame.Services.RoundInfoService
{
    public class RoundInfoService : IRoundInfoService
    {
        public async Task<RoundInfoModel> LoadRoundFromJsonAsync(string path)
        {
            var json = File.ReadAllText(path);
            try
            {
                var model = JsonSerializer.Deserialize<RoundInfoModel>(json);

                if (model is null) throw new Exception("Ошибка загрузки файла игры (неверный формат). Исправьте ошибки и перезагрузите приложение");

                return model;
            }

            catch { throw new Exception("Ошибка загрузки файла игры (неверный формат). Исправьте ошибки и перезагрузите приложение"); }
                
        }

        public async Task WriteRoundToJsonAsync(RoundInfoModel roundInfoModel, string path)
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };

            var json = JsonSerializer.Serialize(roundInfoModel, jsonOptions);

            await File.WriteAllTextAsync(path, json);
        }
    }
}
