using Application.Dtos;
using MediatR;

namespace Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandRequest : IRequest<FacebookLoginCommandResponse>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthToken { get; set; }
        public string PhotoUrl { get; set; }
        public string Provider { get; set; }
        public Response Response { get; set; }
    }

    public class Response
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public Picture Picture { get; set; }
    }

    public class Picture
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public long Height { get; set; }
        public bool Is_silhouette { get; set; }
        public string Url { get; set; }
        public long Width { get; set; }
    }
}

//authToken: "EAAK7mlZBm7c0BAAZACe5qGGrazAw8BiMOqKDzDnyZBFPVozODgHs5RZBtkC2kNlTC8NVQ0XC2g8QIpNje2QFTRzX77ZBHh9iZCXf4eSEec8lvp7ZADjCIUHNe5EQ5zK0yfSe9SZC5IsrlPYdZB5PO3kxY2Gyw2bjalvKEXX5B4Me9rOLtluSLBKNyTEXvAQZBRk1UOyt5EZBHZCCfeNzOsXCzhjZC"
//email: "leffter1999@gmail.com"
//firstName: "Yusuf"
//id: "5801858439842411"
//lastName: "Ünal"
//name: "Yusuf Ünal"
//photoUrl: "https://graph.facebook.com/5801858439842411/picture?type=normal"
//provider: "FACEBOOK"
//response:
        //email: "leffter1999@gmail.com"
        //first_name: "Yusuf"
        //id: "5801858439842411"
        //last_name: "Ünal"
        //name: "Yusuf Ünal"
        //picture:
            //data:
                //height: 50
                //is_silhouette: false
                //url: "https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=5801858439842411&height=50&width=50&ext=1659897755&hash=AeRGqLbMvjv7T6cVIxc"
                //width: 50