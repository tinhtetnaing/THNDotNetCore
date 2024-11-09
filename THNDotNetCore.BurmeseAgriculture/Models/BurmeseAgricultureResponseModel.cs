
public class BurmeseAgricultureReponseModel
{
    public BurmeseAgricultureModel[] Tbl_BurmeseAgriculture { get; set; }
}

public class BurmeseAgricultureModel
{
    public string Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
}
