using YamlDotNet.Serialization;

public class VideoManager
{
	public void LoadAndDisplayVideos(string filePath)
	{
		List<Video> videos = LoadVideoes(filePath);

		// Sort videos by title:
		videos.Sort((v1, v2) => string.Compare(v1._Title, v2._Title, StringComparison.Ordinal));

		//Display information
		foreach (var video in videos)
		{
			DisplayFormat(video);
		}
	}

	private List<Video> LoadVideoes(string filePath)
	{
		List<Video> videos;

		try
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				var deserializer = new DeserializerBuilder().Build();
				videos = deserializer.Deserialize<List<Video>>(reader);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine($"Error loading YAML file: {e.Message}");
			videos = new List<Video>();
		}

		return videos;
	}

	private void DisplayFormat(Video video)
	{
		Console.WriteLine($"\nTile: {video._Title}");
		Console.WriteLine($"Author: {video._Author}");
		Console.WriteLine($"Length: {video._Length.Hours:D2}:{video._Length.Minutes:D2}:{video._Length.Seconds:D2}");
		Console.WriteLine($"Number of Comments: {video.CommentNum()}");

		Console.WriteLine("\nComments:\n");
		foreach (var comment in video._Comments)
		{
			Console.WriteLine($"{comment._CommenterName}: {comment._CommentText}");
		}
		Console.WriteLine("======================================================================================");
		Console.WriteLine();
	}
}