using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace TugasProject
{
    internal class Gate : Asset3d
    {
        List<Asset3d> objectList = new List<Asset3d>();
        List<Asset3d> objectList2 = new List<Asset3d>();
        List<Asset3d> objectList3 = new List<Asset3d>();
        List<Asset3d> objectList4 = new List<Asset3d>();
        List<Asset3d> objectList5 = new List<Asset3d>();
        List<Asset3d> objectList6 = new List<Asset3d>();
        List<Asset3d> objectList7 = new List<Asset3d>();
        List<Asset3d> objectList8 = new List<Asset3d>();
        List<Asset3d> objectList9 = new List<Asset3d>();
        List<Asset3d> objectList10 = new List<Asset3d>();

        double _time;
        float degr = 0;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 0.1f;

        // Animasi naik turun
        float height = 70f;

        static class Constants
        {
            public const string path = "../../../Shaders/";
        }

        public void load()
        {
            var _object3d = new Asset3d(new Vector3(1f, 1f, 1f));
            _object3d.createHemisphere(1f, 1.4f, 0.05f, 0, 0, 0);
            objectList.Add(_object3d);

            _object3d = new Asset3d(new Vector3(1f, 1f, 1f));
            _object3d.createHemisphere(0.6f, 1f, 0.05f, 0, 0, 0);
            objectList2.Add(_object3d);

            // Mickey
            _object3d = new Asset3d(new Vector3(1f, 0f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.1f, 0.1f, 0.1f, 72, 24);
            objectList3.Add(_object3d);

            _object3d = new Asset3d(new Vector3(1f, 0f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.165f, 0.165f, 0.1f, 72, 24);
            objectList4.Add(_object3d);

            // Garis
            _object3d = new Asset3d(new Vector3(0.6f, 0.6f, 0.6f));
            _object3d.AddCoordinates(0f, 1f, 0.038f);
            _object3d.AddCoordinates(0f, 0.75f, 0.038f);
            _object3d.AddCoordinates(0f, 0.25f, 0.038f);
            _object3d.AddCoordinates(0f, 0f, 0.038f);
            _object3d.Bezier3d();
            objectList5.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.6f, 0.6f, 0.6f));
            _object3d.AddCoordinates(0f, 1.327f, 0.049f);
            _object3d.AddCoordinates(0f, 0.75f, 0.049f);
            _object3d.AddCoordinates(0f, 0.25f, 0.049f);
            _object3d.AddCoordinates(0f, 0f, 0.049f);
            _object3d.Bezier3d();
            objectList6.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.6f, 0.6f, 0.6f));
            _object3d.AddCoordinates(0f, 1.4f, 0.055f);
            _object3d.AddCoordinates(0f, 0.75f, 0.055f);
            _object3d.AddCoordinates(0f, 0.25f, 0.055f);
            _object3d.AddCoordinates(0f, 0f, 0.055f);
            _object3d.Bezier3d();
            objectList7.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.6f, 0.6f, 0.6f));
            _object3d.AddCoordinates(0f, 1.21f, 0.049f);
            _object3d.AddCoordinates(0f, 0.75f, 0.049f);
            _object3d.AddCoordinates(0f, 0.25f, 0.049f);
            _object3d.AddCoordinates(0f, 0f, 0.049f);
            _object3d.Bezier3d();
            objectList8.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.6f, 0.6f, 0.6f));
            _object3d.AddCoordinates(0f, 0.95f, 0.049f);
            _object3d.AddCoordinates(0f, 0.75f, 0.049f);
            _object3d.AddCoordinates(0f, 0.25f, 0.049f);
            _object3d.AddCoordinates(0f, 0f, 0.049f);
            _object3d.Bezier3d();
            objectList9.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.6f, 0.6f, 0.6f));
            _object3d.AddCoordinates(0f, 0.95f, 0.049f);
            _object3d.AddCoordinates(0f, 0.75f, 0.049f);
            _object3d.AddCoordinates(0f, 0.25f, 0.049f);
            _object3d.AddCoordinates(0f, 0f, 0.049f);
            _object3d.Bezier3d();
            objectList10.Add(_object3d);

            foreach (Asset3d i in objectList)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList2)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList3)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList4)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList5)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList6)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList7)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList8)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList9)
            {
                i.load(Constants.path, 0);
            }

            foreach (Asset3d i in objectList10)
            {
                i.load(Constants.path, 0);
            }
        }

        public void render(FrameEventArgs args, Camera _camera, float scaling,
            float x, float y, float z)
        {
            Matrix4 temp = Matrix4.Identity;

            if (height >= y)
            {
                height -= 0.2f;
            }

            // Cuma pagar putihnya aja
            temp = temp * Matrix4.CreateTranslation(-1.5f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.4f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList2)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(1.5f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.4f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList2)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Garis dan mirror garis nya
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-2.2f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList5)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(2.2f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList5)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1.8f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList6)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(1.8f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList6)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1.4f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList7)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(1.4f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList7)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList8)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(1f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList8)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.6f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList9)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.6f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList9)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.2f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList10)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.2f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList10)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Mickey
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.15f + x, 0.65f + height, 0f + z);
            foreach (Asset3d i in objectList3)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.15f + x, 0.65f + height, 0f + z);
            foreach (Asset3d i in objectList3)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f + x, 0.53f + height, 0f + z);
            foreach (Asset3d i in objectList4)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
        }
    }
}
