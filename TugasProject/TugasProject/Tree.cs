using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace TugasProject
{
    internal class Tree : Asset3d
    {
        List<Asset3d> objectList = new List<Asset3d>();
        List<Asset3d> objectList2 = new List<Asset3d>();
        List<Asset3d> objectList3 = new List<Asset3d>();
        List<Asset3d> objectList4 = new List<Asset3d>();
        List<Asset3d> objectList5 = new List<Asset3d>();
        List<Asset3d> objectList6 = new List<Asset3d>();
        List<Asset3d> objectList7 = new List<Asset3d>();

        double _time;
        float degr = 0;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 0.1f;

        // Animasi naik turun
        float height = -1.5f;

        static class Constants
        {
            public const string path = "../../../Shaders/";
        }

        public void load()
        {
            // Leaves
            var _object3d = new Asset3d(new Vector3(0.2117f, 0.6f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.14f, 0.14f, 0.14f, 72, 24);
            objectList.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.2117f, 0.6f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.2f, 0.2f, 0.2f, 72, 24);
            objectList2.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.2117f, 0.6f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.1f, 0.1f, 0.1f, 72, 24);
            objectList3.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.2117f, 0.6f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.1f, 0.1f, 0.1f, 72, 24);
            objectList4.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.2117f, 0.6f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.1f, 0.1f, 0.1f, 72, 24);
            objectList5.Add(_object3d);

            _object3d = new Asset3d(new Vector3(0.2117f, 0.6f, 0f));
            _object3d.createEllipsoid(0, 0, 0, 0.1f, 0.1f, 0.1f, 72, 24);
            objectList6.Add(_object3d);

            // Batang
            _object3d = new Asset3d(new Vector3(0.4392f, 0.2509f, 0.1411f));
            _object3d.createCylinder(0, 0, 0, 0.08f, 2.4f);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), 90f);
            objectList7.Add(_object3d);

            foreach (Asset3d i in objectList)
            {
                i.load(Constants.path, 2);
            }
            foreach (Asset3d i in objectList2)
            {
                i.load(Constants.path, 2);
            }
            foreach (Asset3d i in objectList3)
            {
                i.load(Constants.path, 2);
            }
            foreach (Asset3d i in objectList4)
            {
                i.load(Constants.path, 2);
            }
            foreach (Asset3d i in objectList5)
            {
                i.load(Constants.path, 2);
            }
            foreach (Asset3d i in objectList6)
            {
                i.load(Constants.path, 2);
            }
            foreach (Asset3d i in objectList7)
            {
                i.load(Constants.path, 2);
            }
        }

        public void render(FrameEventArgs args, Camera _camera, float scaling, 
            float x, float y, float z)
        {
            Matrix4 temp = Matrix4.Identity;

            if (height <= y)
            {
                height += 0.003f;
            }

            // Batang
            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f + x, 0f + height, 0f + z);
            foreach (Asset3d i in objectList7)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Leaves
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.15f + x, 0.1f + height, 0f + z);
            foreach (Asset3d i in objectList)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f + x, 0.15f + height, 0f + z);
            foreach (Asset3d i in objectList2)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.15f + x, 0.05f + height, 0f + z);
            foreach (Asset3d i in objectList3)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f + x, 0.05f + height, 0.15f + z);
            foreach (Asset3d i in objectList4)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f + x, 0.05f + height, -0.15f + z);
            foreach (Asset3d i in objectList5)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f + x, 0.05f + height, 0f + z);
            foreach (Asset3d i in objectList6)
            {
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
        }
    }
}
