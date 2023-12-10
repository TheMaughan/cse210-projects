using System;

class Program
{
    static void Main(string[] args)
    {
        VideoManager videoManager = new VideoManager();
        videoManager.LoadAndDisplayVideos("videoData.yaml");
    }
}