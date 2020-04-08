
namespace bdv
{
    public interface IEntity
    {
        int id { get; set; }
        Model mdl { get; set; }
        Point<float> position { get; set; }
        Point<float> speed { get; set; }
        Dimension dimension { get; set; }
        RGBA color { get; set; }
        Point<float> middle { get; set; }
        bool player { get; set; }
        Script script { get; set; }
        CustomVector2D vector { get; set; }
        Entity referenced { get; set; }
        bool following { get; set; }
        bool lockMovement { get; set; }
        string message { get; set; }
        Texture texture { get; set; }
    }
}