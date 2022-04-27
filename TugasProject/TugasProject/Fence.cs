using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace TugasProject
{
    internal class Fence : Asset3d
    {
        List<Asset3d> objectList = new List<Asset3d>();

        float height = 17f;
        float rotationPower = 0f;

        static class Constants
        {
            public const string path = "../../../Shaders/";
        }

        public void load(float axisX, float axisY, float axisZ, float rotation)
        {
            var _object3d = new Asset3d(new Vector3(1f, 1f, 0.3f));
            _object3d.createHemisphere(1f, 0.3f, 0.05f, 0, 0, 0);
            _object3d.Rotate((0, 0, 0), (axisX, axisY, axisZ), rotation);
            objectList.Add(_object3d);

            foreach(Asset3d i in objectList)
            {
                i.load(Constants.path, 0);
            }
        }

        public void render(FrameEventArgs args, Camera _camera, float scaling,
            float x, float y, float z)
        {
            Matrix4 temp = Matrix4.Identity;
            if (height > y)
            {
                height -= 0.05f;
            }
            temp = temp * Matrix4.CreateTranslation(x, height, z);

            // Untuk animasi rotation
            //if (rotationPower < 360f)
            //{
            //    rotationPower += 0.005f;
            //}

            foreach (Asset3d i in objectList)
            {
                //i.Rotate((0, 0, 0), (0, 0, 1), rotationPower);
                i.render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
            
        }
    }
}
