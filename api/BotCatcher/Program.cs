var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var allowedList = new Dictionary<string, List<string>>
{
    {
        "Chromium Browser", [
            "t13d1516h2_8daaf6152771_02713d6af862",
            "q13d0312h3_55b375c5d22e_06cda9e17597",
            "t13d1517h2_8daaf6152771_b0da82dd1658",
            "t13d1517h2_8daaf6152771_b1ff8ab2d16f",
            "t13i1515h2_8daaf6152771_02713d6af862",
            "q13i0311h3_55b375c5d22e_06cda9e17597",
            "t13i1516h2_8daaf6152771_b0da82dd1658",
            "t13i1516h2_8daaf6152771_b1ff8ab2d16f",
            "t13d1517h2_8daaf6152771_e903c750b005",
            "t13d1516h2_8daaf6152771_d8a2da3f94cd"
        ]
    },
    {
        "Mozilla Firefox", [
            "t13d1715h2_5b57614c22b0_7121afd63204",
            "t13i1714h2_5b57614c22b0_7121afd63204",
            "t13d1716h2_5b57614c22b0_eeeea6562960",
            "t13d1712h2_5b57614c22b0_6acbe59d8432",
            "t13d1714h2_5b57614c22b0_87e72e8c75e3",
            "t13d1716h2_5b57614c22b0_cc464264ebd5",
            "t13d1716h2_5b57614c22b0_5713ffdeb7a1"
        ]
    },
    {
        "Safari", [
            "t13d2014h2_a09f3c656075_14788d8d241b",
            "t13i2013h2_a09f3c656075_14788d8d241b",
            "t13d1714h2_5b57614c22b0_e42f34c56612",
            "t13d1714h2_5b57614c22b0_14788d8d241b"
        ]
    }
};

app.MapGet("/", (HttpContext httpContext) =>
{
    var ja4Header = httpContext.Request.Headers["ja4"].ToString();

    if (allowedList.Any(x => x.Value.Contains(ja4Header)))
    {
        return Results.Ok("Hoş geldin! bot değilsin.");
    }

    Console.WriteLine(ja4Header);

    return Results.Ok("Bot yakalandı!");
});

app.Run();
