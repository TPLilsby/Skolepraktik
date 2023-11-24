namespace MusicLibrary
{
    public class Artist
    {
        public int Id { get; }
        public string Name { get; }
        public string ImagePath { get; }
        public string  Link { get; }

        public Artist(int id, string name, string imagePath, string link)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
            Link = link;
        }
    }
}
