using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace TugasProject
{
    internal class Jefry : Asset3d
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
        float minHeightFloatingCone = -0.9f;
        float maxHeightFloatingCone = -0.8f;
        float heightFloatingCone = -0.85f;
        bool floatingConeDir = false;
        float minHeightFloatingRing = -0.05f;
        float maxHeightFloatingRing = -0.02f;
        float heightFloatingRing = -0.05f;
        bool floatingRingDir = false;

        static class Constants
        {
            public const string path = "../../../Shaders/";
        }

        public void load()
        {
            // Ellipsoid
            //var _object3d = new Asset3d(new Vector3(0, 0.5f, 1));
            //_object3d.createEllipsoid(0, 0, 0, 0.7f, 0.2f, 0.9f);
            //objectList.Add(_object3d);

            // Ellipsoid2
            var _object3d = new Asset3d(new Vector3(0.2705f, 1f, 0.3803f));
            _object3d.createEllipsoid(0, 0, 0, 0.8f, 0.8f, 0.05f, 72, 24);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), -90f);
            objectList.Add(_object3d);

            // Cone
            _object3d = new Asset3d(new Vector3(0, 0.5f, 1));
            _object3d.createCone(0, 0, 0, 0.4f, 0.4f, 0.4f);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), 90f);
            objectList2.Add(_object3d);

            // Box
            _object3d = new Asset3d(new Vector3(1f, 1f, 0f));
            _object3d.createBoxVertices(0, 0, 0, 0.004f, 0.1f, 0.1f, 0.1f);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), 45f);
            objectList3.Add(_object3d);

            _object3d = new Asset3d(new Vector3(1f, 1f, 0f));
            _object3d.createBoxVertices(0, 0, 0, 0.004f, 0.1f, 0.1f, 0.1f);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), 45f);
            objectList4.Add(_object3d);

            // Ring
            _object3d = new Asset3d(new Vector3(1f, 1f, 0.3f));
            _object3d.createCylinder(0, 0, 0, 1.2f, 0.01f);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), 90f);
            objectList5.Add(_object3d);

            // Bezier
            _object3d = new Asset3d(new Vector3(1f, 0f, 0f));
            _object3d.AddCoordinates(-0.4f, 1.2f, 0f);
            _object3d.AddCoordinates(-0.4f, 2.2f, 0f);
            _object3d.AddCoordinates(-0.4f, 2.2f, 0f);
            _object3d.AddCoordinates(0f, 1.2f, 0f);
            _object3d.Bezier3d();
            objectList6.Add(_object3d);

            // Bezier
            _object3d = new Asset3d(new Vector3(1f, 0f, 0f));
            _object3d.AddCoordinates(0f, 1.2f, 0f);
            _object3d.AddCoordinates(0.4f, 2.2f, 0f);
            _object3d.AddCoordinates(0.4f, 2.2f, 0f);
            _object3d.AddCoordinates(0.4f, 1.2f, 0f);
            _object3d.Bezier3d();
            objectList6.Add(_object3d);

            // Torus
            _object3d = new Asset3d(new Vector3(1f, 1f, 0.3f));
            _object3d.createTorus(0, 0, 0, 0.3f, 0.01f);
            _object3d.Rotate((0, 0, 0), (1, 0, 0), 120f);
            objectList7.Add(_object3d);

            foreach (Asset3d i in objectList)
            {
                i.load(Constants.path, 0);
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
                i.load(Constants.path, 1);
            }
            foreach (Asset3d i in objectList6)
            {
                i.load(Constants.path, 0);
            }
            foreach (Asset3d i in objectList7)
            {
                i.load(Constants.path, 0);
            }
        }

        public void render(FrameEventArgs args, Camera _camera)
        {
            Matrix4 temp = Matrix4.Identity;

            // Cone Floating Island
            if (heightFloatingCone > maxHeightFloatingCone)
            {
                // Arah akan kebawah
                floatingConeDir = true;
            }
            else if (heightFloatingCone < minHeightFloatingCone)
            {
                // Arah akan keatas
                floatingConeDir = false;
            }
            // Speed translasi naik turun
            if (floatingConeDir)
            {
                heightFloatingCone -= 0.00002f;
            }
            else
            {
                heightFloatingCone += 0.00002f;
            }
            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f, heightFloatingCone, 0f);
            foreach (Asset3d i in objectList2)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Floating Asteroid
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1.1f, -0.15f, 0f);
            degr += MathHelper.DegreesToRadians(0.012f);
            temp = temp * Matrix4.CreateRotationY(degr);
            foreach (Asset3d i in objectList3)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            temp = Matrix4.Identity * Matrix4.CreateTranslation(1.1f, -0.15f, 0f);
            degr += MathHelper.DegreesToRadians(0.012f);
            temp = temp * Matrix4.CreateRotationY(degr);
            foreach (Asset3d i in objectList4)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Ring
            if (heightFloatingRing > maxHeightFloatingRing)
            {
                floatingRingDir = true;
            }
            else if (heightFloatingRing < minHeightFloatingRing)
            {
                floatingRingDir = false;
            }
            if (floatingRingDir)
            {
                heightFloatingRing -= 0.000007f;
            }
            else
            {
                heightFloatingRing += 0.000007f;
            }
            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f, heightFloatingRing, 0f);
            foreach (Asset3d i in objectList5)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Land
            temp = Matrix4.Identity;
            foreach (Asset3d i in objectList)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Bezier
            temp = Matrix4.Identity;
            foreach (Asset3d i in objectList6)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }

            // Torus
            temp = Matrix4.Identity * Matrix4.CreateTranslation(0f, 2.2f, 0f);
            foreach (Asset3d i in objectList7)
            {
                i.render(temp, 1f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
        }
    }
}
