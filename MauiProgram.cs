using SQLite;

namespace MauiHang;

[Table("KeyValueModel")]
public class KeyValueModel
{
    [PrimaryKey]
    public string? Key { get; set; }

    public string? Value { get; set; }
}


public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

        var options = new SQLiteConnectionString(Path.Combine(FileSystem.Current.AppDataDirectory, "test.db"),
            SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex,
            false, key: @"Mauihang");
        var db = new SQLiteAsyncConnection(options);
        _ = db.CreateTableAsync<KeyValueModel>();


        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
