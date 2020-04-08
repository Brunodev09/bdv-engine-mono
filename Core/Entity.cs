namespace bdv
{
    public class Entity : IEntity
    {
        public static int AutoId;
        public int id { get; set; }
        public Model mdl { get; set; }
        public Point<float> position { get; set; }
        public Point<float> speed { get; set; }
        public Dimension dimension { get; set; }
        public RGBA color { get; set; }
        public Point<float> middle { get; set; }
        public bool player { get; set; }
        public Script script { get; set; }
        public CustomVector2D vector { get; set; }
        public Entity referenced { get; set; }
        public bool following { get; set; }
        public bool lockMovement { get; set; }
        public string message { get; set; }
        public Texture texture { get; set; }
        public SpriteSheet sprite { get; set; }

        public delegate string Callback(string val);
        public Callback callback;
        public GenericDictionary props = new GenericDictionary();

        public Entity(Point<float> position, Dimension dimension, RGBA color)
        {
            AutoId++;
            this.id = AutoId;
            this.mdl = Model.PIXEL;
            this.position = position;
            this.dimension = dimension;
            this.color = color;
            this.speed = Point<float>.Factory(0.0f, 0.0f);

            this.middle = Point<float>.Factory(
                position.x + (float)(this.dimension.Width / 2),
                 position.y + (float)(this.dimension.Height / 2));
        }

        public Entity(Point<float> position, Dimension dimension, Texture texture)
        {
            AutoId++;
            this.mdl = Model.TEXTURE;
            this.id = AutoId;
            this.position = position;
            this.dimension = dimension;
            this.speed = Point<float>.Factory(0.0f, 0.0f);
            this.texture = texture;
        }

        public Entity(Point<float> position, Dimension dimension, SpriteSheet sprite)
        {
            AutoId++;
            this.mdl = Model.SPRITESHEET;
            this.id = AutoId;
            this.position = position;
            this.dimension = dimension;
            this.speed = Point<float>.Factory(0.0f, 0.0f);
            this.sprite = sprite;
        }

        public void Add<T>(string key, T val) where T : class
        {
            this.props.Set(key, val);
        }

        public T Get<T>(string key) where T : class
        {
            return this.props.Get<T>(key);
        }

        public void SetCallback(Callback cb)
        {
            this.callback = cb;
        }

        public void SetSpeed(Point<float> speed)
        {
            this.speed.x = speed.x;
            this.speed.y = speed.y;
        }

        public void Transform(string axis, Point<float> speed)
        {
            switch (axis)
            {
                case "X":
                    {
                        this.speed.x = speed.x;
                        break;
                    }
                case "Y":
                    {
                        this.speed.y = speed.y;
                        break;
                    }
                default:
                    {
                        this.speed.x = speed.x;
                        this.speed.y = speed.y;
                        break;
                    }
            }

        }

        public void Update()
        {

        }
    }
}