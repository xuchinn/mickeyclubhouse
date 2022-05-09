using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace TugasProject
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        Camera _camera;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 1.0f;

        FloatingIsland floatingIsland = new FloatingIsland();
        Tree tree = new Tree();
        Fence fence = new Fence();
        Fence fence2 = new Fence();
        Fence fence3 = new Fence();
        Fence fence4 = new Fence();
        Gate gate = new Gate();
        Clubhouse clubhouse = new Clubhouse();
        Rocks rocks = new Rocks();
        Mickey mickey = new Mickey();
        Mouseketool mouseketool = new Mouseketool();
        Balloon balloon = new Balloon();
        bool up = true;
        float max = 0f;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            Console.WriteLine("Tekan W untuk maju");
            Console.WriteLine("Tekan S untuk mundur");
            Console.WriteLine("Tekan A untuk ke kiri");
            Console.WriteLine("Tekan D untuk ke kanan");
            Console.WriteLine("Tekan Up Arrow untuk memutar ke atas");
            Console.WriteLine("Tekan Down Arrow untuk memutar ke bawah");
            Console.WriteLine("Tekan Left Arrow untuk memutar ke kiri");
            Console.WriteLine("Tekan Right Arrow untuk memutar ke kanan");
            Console.WriteLine("Tekan PageUp Arrow untuk naik ke atas");
            Console.WriteLine("Tekan PageDown Arrow untuk turun ke bawah");

            base.OnLoad();
            ////Biar ga kedobelan
            GL.Enable(EnableCap.DepthTest);
            //Ganti background warna
            GL.ClearColor(0.4f, 0.75f, 1.0f, 1.0f);
            _camera = new Camera(new Vector3(0, 0, 1), Size.X / Size.Y);
            _camera.Position -= _camera.Front * 3f;
            _camera.Position += _camera.Up * 1.5f;

            // Kelly
            clubhouse.initObjects();
            clubhouse.load();

            rocks.initObjects();
            rocks.load();

            // Xuchin
            mickey.loadObjects();
            mouseketool.loadObjects();

            // Adrian
            balloon.loadObjects();

            // Jefry
            floatingIsland.load();

            tree.load();

            gate.load();
            fence.load(0, 1, 0, -65f);
            fence2.load(0, 1, 0, -30f);
            fence3.load(0, 1, 0, 65f);
            fence4.load(0, 1, 0, 30f);

            CursorGrabbed = false; //Buat mouse ga keliatan di display (true)
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Kelly
            clubhouse.renderObjects(_camera, 1.0f, args, 0.0f, -0.1f, 0.0f);
            rocks.renderObjects(_camera, 0.8f, args, 0.4f, 0.0f, 0.05f);

            // Xuchin
            mickey.renderObjects(args, _camera, 0.15f, 2.7f, 2f, 8f);

            if (up == true)
            {
                max += 0.005f;
                if (max >= 0.2f)
                {
                    up = false;
                }
            }
            else
            {
                max -= 0.005f;
                if (max <= 0f)
                {
                    up = true;
                }
            }
            mouseketool.renderObjects(args, _camera, 0.7f, 0.0f, 5.0f + max, 0.0f);

            // Adrian
            balloon.renderObjects(args, _camera, 0.5f, -0.8f, 1.7f, 0);

            // Jefry
            floatingIsland.render(args, _camera, 2f);

            tree.render(args, _camera, 0.8f, 1.3f, 0.2f, -1f);
            tree.render(args, _camera, 0.8f, 0.85f, 0.2f, -1.33f);
            tree.render(args, _camera, 0.8f, 0.45f, 0.2f, -1.15f);
            tree.render(args, _camera, 0.8f, -0.6f, 0.2f, -1.35f);
            tree.render(args, _camera, 0.8f, -0.9f, 0.2f, -1f);
            tree.render(args, _camera, 0.8f, -1.3f, 0.2f, -1.2f);

            gate.render(args, _camera, 0.15f, 0f, 0f, 10f);
            fence.render(args, _camera, 0.49f, -2.77f, 0.0f, 1.25f);
            fence2.render(args, _camera, 0.49f, -1.5f, 0.0f, 2.65f);
            fence3.render(args, _camera, 0.49f, 2.77f, 0.0f, 1.25f);
            fence4.render(args, _camera, 0.49f, 1.5f, 0.0f, 2.65f);

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            float cameraSpeed = 8f;
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            // Lawan jarum jam
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(
                    _camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position
                    - _objectPos);
            }
            // Searah jarum jam
            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            // Atas
            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            // Bawah
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }

            if (input.IsKeyDown(Keys.PageUp))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.PageDown))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButton.Left)
            {
                float _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
                //Hasil y ini nanti kebalik angka nya makanya dikasi - biar normal
                float _y = -(MousePosition.Y - Size.Y / 2) / (Size.Y / 2);

                //_object[3].updateMousePosition(_x, _y);
            }
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }
    }
}
