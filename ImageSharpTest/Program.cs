// See https://aka.ms/new-console-template for more information

using System.Numerics;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Tga;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

foreach (var t in Enumerable.Range(0, 150))
{
    var img = new Image<Bgr565>(200, 100, new Bgr565());
    var fontCollection = new FontCollection();
    var ff = new FontFamily();
    var random = new Random();
    var colors = new Color[]
    {
        Color.Blue,
        Color.Red,
        Color.Gray,
        Color.Green,
        Color.Black
    };
    fontCollection.Add("ShortBaby-Mg2w.ttf");
    FontFamily family = fontCollection.Get("Short Baby");
    var font = family.CreateFont(65, FontStyle.Italic);
    var value = $"{random.Next(1111, 9999)}";

    img.Mutate(x => x.Fill(Color.White));
    DrawingOptions doe = new DrawingOptions();
    for (int i = 0; i < value.Length; i++)
    {
        var x = i * 40 + random.Next(20, 35);
        var y = 35 + random.Next(-20, 20);
        img.Mutate(c => c.DrawText(
            new DrawingOptions { 
                Transform = Matrix3x2Extensions.CreateRotationDegrees(random.Next(-30, 35), new PointF(x, y))
            },
            value[i].ToString(), font, colors[random.Next(5)],
            new PointF(x, y)
        ));
    }

    for (int j = 0; j < random.Next(3, 5); j++)
    {
        var brush = new SolidBrush(colors[random.Next(5)]);
        img.Mutate(x =>
            x.DrawBeziers(new DrawingOptions(), brush, random.Next(2, 5) * 1.5f, 
                new PointF(0, random.Next(100)),
                new PointF(random.Next(0,200), random.Next(0, 100)),
                new PointF(random.Next(0,200), random.Next(0,100)),
                new PointF(200, random.Next(100))
            )
        );
    }

    var o  = img.ToBase64String(PngFormat.Instance);
    img.SaveAsJpeg($"images/{value}.jpg");
}

Console.WriteLine("Hello, World!");