namespace Keepr.Models;

public class Profile : RepoItem<string>
{
    public string Name { get; set; }
    public string Picture { get; set; }
    public string CoverImg { get; set; } = "https://images.unsplash.com/photo-1425913397330-cf8af2ff40a1?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8Zm9yZXN0fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60";
}

public class Account : Profile
{
    public string Email { get; set; }
}
