namespace MusicLibrary
{
    public class Album
    {
        public int Id { get; }
        public string Name { get; }
        public int ArtistId { get; }
        public string ImagePath { get; }

        public Album(int id, string name, int artistId, string imagePath)
        {
            Id = id;
            Name = name;
            ArtistId = artistId;
            ImagePath = imagePath;
        }
    }
}
