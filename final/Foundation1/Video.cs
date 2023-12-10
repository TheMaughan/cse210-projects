public class Video
{
	public string _Title { get; set; }
	public string _Author { get; set; }
	public TimeSpan _Length { get; set; }
	public List<Comment> _Comments { get; set; }

	public Video()
	{
		_Comments = new List<Comment>();
	}

	public int CommentNum()
	{
		return _Comments.Count;
	}
}