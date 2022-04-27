using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace TugasProject
{
    internal class Mouseketool : Asset3d
    {
        List<Asset3d> mouseketool = new List<Asset3d>();
        Vector3 pink = new Vector3(0.831f, 0.662f, 0.623f);
        Vector3 white = new Vector3(1.0f, 1.0f, 1.0f);
        Vector3 beige = new Vector3(0.847f, 0.819f, 0.623f);
        Vector3 red = new Vector3(0.996f, 0.141f, 0.203f);
        Vector3 yellow = new Vector3(1f, 0.917f, 0.133f);
        Vector3 blue = new Vector3(0.556f, 0.796f, 0.913f);

        

        public Mouseketool()
        {
        }
        public void setObjects()
        {
            var temp = new Asset3d();
            temp.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.1f, 0.5f);
            temp.setColor(yellow);
            mouseketool.Add(temp);

            temp = new Asset3d();
            temp.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.05f, 0.52f);
            temp.setColor(red);
            mouseketool.Add(temp);

            // telinga
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.48f, 0.48f, 0.01f, 72, 24);
            temp.setColor(white);
            mouseketool.Add(temp);

            // kepala
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.49f, 0.49f, 0.01f, 72, 24);
            temp.setColor(white);
            mouseketool.Add(temp);
            
            // kepala
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.47f, 0.47f, 0.01f, 72, 24);
            temp.setColor(blue);
            mouseketool.Add(temp);

            
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.445f, 0.445f, 0.01f, 72, 24);
            temp.setColor(red);
            mouseketool.Add(temp);

            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.2f, 0.2f, 0.01f, 72, 24);
            temp.setColor(yellow);
            mouseketool.Add(temp);

            temp = new Asset3d();
            temp.createHemisphere(0.1f, 0.1f, 0.01f, 0.0f, 0.0f, 0.0f);
            temp.setColor(red);
            mouseketool.Add(temp);

            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.1f, 0.1f, 0.01f, 72, 24);
            temp.setColor(beige);
            mouseketool.Add(temp);

            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.1f, 0.1f, 0.01f, 72, 24);
            temp.setColor(pink);
            mouseketool.Add(temp);
        }
        public void loadObjects()
        {
            setObjects();
            foreach (Asset3d _object in mouseketool)
            {
                _object.load(Constants.path, 0);
            }
        }
        public void renderObjects(FrameEventArgs args, Camera _camera, float scaling, float x, float y, float z)
        {
            Matrix4 temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.0f + z);
            mouseketool[0].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.0f + z);
            mouseketool[1].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            // left ear
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(-1f + x, 4f + y, 0.0f + z);
            mouseketool[0].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(-1f + x, 4f + y, 0.0f + z);
            mouseketool[1].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            // right ear
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(1f + x, 4f + y, 0.0f + z);
            mouseketool[0].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(1f + x, 4f + y, 0.0f + z);
            mouseketool[1].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-1f + x, 4f + y, 0.05f + z);
            mouseketool[2].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(1f + x, 4f + y, 0.05f + z);
            mouseketool[2].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.05f + z);
            mouseketool[3].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.06f + z);
            mouseketool[4].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-1f + x, 4f + y, 0.06f + z);
            mouseketool[5].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(1f + x, 4f + y, 0.06f + z);
            mouseketool[5].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-1f + x, 4f + y, 0.09f + z);
            mouseketool[6].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(1f + x, 4f + y, 0.09f + z);
            mouseketool[6].render(temp, scaling * 0.5f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0f + x, -0.44f + y, 0.1f + z);
            mouseketool[7].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
            temp = temp * Matrix4.CreateTranslation(0f + x, 0.44f + y, 0.1f + z);
            mouseketool[7].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-90f));
            temp = temp * Matrix4.CreateTranslation(-0.44f + x, 0.0f + y, 0.1f + z);
            mouseketool[7].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.44f + x, 0.0f + y, 0.1f + z);
            mouseketool[7].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.2f + x, 0.2f + y, 0.1f + z);
            mouseketool[8].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.02f + x, -0.2f + y, 0.1f + z);
            mouseketool[8].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.29f + x, 0.9f + y, 0.1f + z);
            mouseketool[8].render(temp, scaling * 0.7f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.27f + x, 1.15f + y, 0.1f + z);
            mouseketool[8].render(temp, scaling * 0.8f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.15f + x, 0.0f + y, 0.1f + z);
            mouseketool[9].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.3f + x, 0.45f + y, 0.1f + z);
            mouseketool[9].render(temp, scaling * 0.85f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 1.4f + y, 0.1f + z);
            mouseketool[9].render(temp, scaling * 0.75f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.32f + x, 0.7f + y, 0.1f + z);
            mouseketool[9].render(temp, scaling * 0.75f, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
    }
}
