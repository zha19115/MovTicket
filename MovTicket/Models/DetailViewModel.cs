using MovTicket.Models.Entities;

namespace MovTicket.Models
{
    public class DetailViewModel
    {
        public int m_id { get; set; }
        public string m_title { get; set; }
        public string m_genre { get; set; }
        public DateOnly m_releaseDate { get; set; }
        public string m_room { get; set; }
        public DateTime m_showTime { get; set; }

    }
}
