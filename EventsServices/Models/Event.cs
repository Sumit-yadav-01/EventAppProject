using System.Text.Json;

namespace EventsServices.Models
{
  public class AccessMethod
  {
    public string method { get; set; }
    public DateTime created_at { get; set; }
    public bool employee_only { get; set; }
  }

  public class Announcements
  {
  }

  public class Colors
  {
    public List<string> all { get; set; }
    public string iconic { get; set; }
    public List<string> primary { get; set; }
  }

  public class Division
  {
    public int taxonomy_id { get; set; }
    public string short_name { get; set; }
    public string display_name { get; set; }
    public string display_type { get; set; }
    public int division_level { get; set; }
    public string slug { get; set; }
  }

  public class DocumentSource
  {
    public string source_type { get; set; }
    public string generation_type { get; set; }
  }

  public class Event
  {
    public string type { get; set; }
    public int id { get; set; }
    public DateTime datetime_utc { get; set; }
    public Venue venue { get; set; }
    public bool datetime_tbd { get; set; }
    public List<Performer> performers { get; set; }
    public bool is_open { get; set; }
    public List<object> links { get; set; }
    public DateTime datetime_local { get; set; }
    public bool time_tbd { get; set; }
    public string short_title { get; set; }
    public DateTime visible_until_utc { get; set; }
    public Stats stats { get; set; }
    public List<Taxonomy> taxonomies { get; set; }
    public string url { get; set; }
    public double score { get; set; }
    public DateTime announce_date { get; set; }
    public DateTime created_at { get; set; }
    public bool date_tbd { get; set; }
    public string title { get; set; }
    public double popularity { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public AccessMethod access_method { get; set; }
    public object event_promotion { get; set; }
    public Announcements announcements { get; set; }
    public bool conditional { get; set; }
    public DateTime enddatetime_utc { get; set; }
    public DateTime? visible_at { get; set; }
    public string is_visible_override { get; set; }
    public int tdc_pvo_id { get; set; }
    public int tdc_pv_id { get; set; }
    public bool is_visible { get; set; }
    public List<PerformerOrder> performer_order { get; set; }
    public Integrated integrated { get; set; }
    public bool general_admission { get; set; }
    public List<object> themes { get; set; }
    public List<object> domain_information { get; set; }
  }

  public class Genre
  {
    public int id { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
    public bool primary { get; set; }
    public Images images { get; set; }
    public string image { get; set; }
    public DocumentSource document_source { get; set; }
  }

  public class Images
  {
    public string huge { get; set; }

    //[JsonProperty("1200x525")]
    //public string _1200x525 { get; set; }

    //[JsonProperty("1200x627")]
    //public string _1200x627 { get; set; }

    //[JsonProperty("136x136")]
    //public string _136x136 { get; set; }

    //[JsonProperty("500_700")]
    //public string _500_700 { get; set; }

    //[JsonProperty("800x320")]
    //public string _800x320 { get; set; }
    //public string banner { get; set; }
    //public string block { get; set; }
    //public string criteo_130_160 { get; set; }
    //public string criteo_170_235 { get; set; }
    //public string criteo_205_100 { get; set; }
    //public string criteo_400_300 { get; set; }
    //public string fb_100x72 { get; set; }
    //public string fb_600_315 { get; set; }
    //public string ipad_event_modal { get; set; }
    //public string ipad_header { get; set; }
    //public string ipad_mini_explore { get; set; }
    //public string mongo { get; set; }
    //public string square_mid { get; set; }
    //public string triggit_fb_ad { get; set; }
  }

  public class Integrated
  {
    public string provider_name { get; set; }
    public string provider_id { get; set; }
  }

  public class Location
  {
    public double lat { get; set; }
    public double lon { get; set; }
  }

  public class Meta
  {
    public int total { get; set; }
    public int took { get; set; }
    public int page { get; set; }
    public int per_page { get; set; }
    public object geolocation { get; set; }
  }

  public class Performer
  {
    public string type { get; set; }
    public string name { get; set; }
    public string image { get; set; }
    public int id { get; set; }
    public Images images { get; set; }
    public List<Division> divisions { get; set; }
    public bool has_upcoming_events { get; set; }
    public bool primary { get; set; }
    public Stats stats { get; set; }
    public List<Taxonomy> taxonomies { get; set; }
    public string image_attribution { get; set; }
    public string url { get; set; }
    public double score { get; set; }
    public string slug { get; set; }
    public int? home_venue_id { get; set; }
    public string short_name { get; set; }
    public int num_upcoming_events { get; set; }
    public Colors colors { get; set; }
    public string image_license { get; set; }
    public int popularity { get; set; }
    public bool home_team { get; set; }
    public Location location { get; set; }
    public string image_rights_message { get; set; }
    public bool? away_team { get; set; }
    public List<Genre> genres { get; set; }
  }

  public class PerformerOrder
  {
    public int id { get; set; }
    public int ordinal { get; set; }
  }

  public class Events
  {
    public List<Event> events { get; set; }
    public Meta meta { get; set; }
  }

  public class Stats
  {
    public int event_count { get; set; }
    public int? listing_count { get; set; }
    public int? average_price { get; set; }
    public int? lowest_price_good_deals { get; set; }
    public int? lowest_price { get; set; }
    public int? highest_price { get; set; }
    public int? visible_listing_count { get; set; }
    public List<int> dq_bucket_counts { get; set; }
    public int? median_price { get; set; }
    public int? lowest_sg_base_price { get; set; }
    public int? lowest_sg_base_price_good_deals { get; set; }
    public int? ticket_count { get; set; }
  }

  public class Taxonomy
  {
    public int id { get; set; }
    public string name { get; set; }
    public int? parent_id { get; set; }
    public DocumentSource document_source { get; set; }
    public int rank { get; set; }
    public string seo_event_type { get; set; }
  }

  public class Venue
  {
    public string state { get; set; }
    public string name_v2 { get; set; }
    public string postal_code { get; set; }
    public string name { get; set; }
    public List<object> links { get; set; }
    public string timezone { get; set; }
    public string url { get; set; }
    public double score { get; set; }
    public Location location { get; set; }
    public string address { get; set; }
    public string country { get; set; }
    public bool has_upcoming_events { get; set; }
    public int num_upcoming_events { get; set; }
    public string city { get; set; }
    public string slug { get; set; }
    public string extended_address { get; set; }
    public int id { get; set; }
    public int popularity { get; set; }
    public AccessMethod access_method { get; set; }
    public int metro_code { get; set; }
    public int capacity { get; set; }
    public string display_location { get; set; }
  }

  public class EventDetails
  {
    public string type { get; set; }
    public int id { get; set; }
    public DateTime datetime_utc { get; set; }
    public Venue venue { get; set; }
    public bool datetime_tbd { get; set; }
    public List<Performer> performers { get; set; }
    public bool is_open { get; set; }
    public List<object> links { get; set; }
    public DateTime datetime_local { get; set; }
    public bool time_tbd { get; set; }
    public string short_title { get; set; }
    public DateTime visible_until_utc { get; set; }
    public Stats stats { get; set; }
    public List<Taxonomy> taxonomies { get; set; }
    public string url { get; set; }
    public double score { get; set; }
    public DateTime announce_date { get; set; }
    public DateTime created_at { get; set; }
    public bool date_tbd { get; set; }
    public string title { get; set; }
    public double popularity { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public AccessMethod access_method { get; set; }
    public object event_promotion { get; set; }
    public Announcements announcements { get; set; }
    public bool conditional { get; set; }
    public DateTime enddatetime_utc { get; set; }
    public object visible_at { get; set; }
    public string is_visible_override { get; set; }
    public int tdc_pvo_id { get; set; }
    public int tdc_pv_id { get; set; }
    public bool is_visible { get; set; }
    public List<PerformerOrder> performer_order { get; set; }
    public object integrated { get; set; }
    public List<object> themes { get; set; }
    public List<object> domain_information { get; set; }
  }

}
