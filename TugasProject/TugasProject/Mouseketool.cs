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
            // kepala utama
            var temp = new Asset3d();
            temp.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.1f, 0.5f);
            temp.setColor(yellow);
            mouseketool.Add(temp);
            // kepala lapisan luar
            temp = new Asset3d();
            temp.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.05f, 0.52f);
            temp.setColor(red);
            mouseketool.Add(temp);
            // kepala depan 
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.465f, 0.465f, 0.0f, 72, 24);
            temp.setColor(white) ;
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.445f, 0.445f, 0.0f, 72, 24);
            temp.setColor(red);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.438f, 0.438f, 0.0f, 72, 24);
            temp.setColor(blue);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createHemisphere(0.1f, 0.1f, 0.01f, 0.0f, 0.0f, 0.0f);
            temp.setColor(red);
            mouseketool.Add(temp);
            mouseketool.Add(temp);
            mouseketool.Add(temp);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.115f, 0.115f, 0.0f, 72, 24);
            temp.setColor(beige);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.055f, 0.055f, 0.0f, 72, 24);
            temp.setColor(beige);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.03f, 0.03f, 0.0f, 72, 24);
            temp.setColor(beige);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.055f, 0.055f, 0.0f, 72, 24);
            temp.setColor(pink);
            mouseketool.Add(temp);

            // telinga utama
            temp = new Asset3d();
            temp.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.08f, 0.2f);
            temp.setColor(yellow);
            mouseketool.Add(temp);
            // telinga lapisan luar
            temp = new Asset3d();
            temp.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.05f, 0.22f);
            temp.setColor(red);
            mouseketool.Add(temp);
            //telinga depan
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.19f, 0.19f, 0.0f, 72, 24);
            temp.setColor(white);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.178f, 0.178f, 0.0f, 72, 24);
            temp.setColor(red);
            mouseketool.Add(temp);
            temp = new Asset3d();
            temp.createEllipsoid(0.0f, 0.0f, 0.0f, 0.08f, 0.08f, 0.0f, 72, 24);
            temp.setColor(yellow);
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
            // kepala
            Matrix4 temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.0f + z);
            mouseketool[0].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.0f + z);
            mouseketool[1].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.055f + z);
            mouseketool[2].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.06f + z);
            mouseketool[3].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.065f + z);
            mouseketool[4].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0f + x, -0.425f + y, 0.068f + z);
            mouseketool[5].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
            temp = temp * Matrix4.CreateTranslation(0f + x, 0.425f + y, 0.068f + z);
            mouseketool[6].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-90f));
            temp = temp * Matrix4.CreateTranslation(-0.425f + x, 0.0f + y, 0.068f + z);
            mouseketool[7].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.425f + x, 0.0f + y, 0.068f + z);
            mouseketool[8].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.198f + x, 0.135f + y, 0.07f + z);
            mouseketool[9].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.05f + x, 0.18f + y, 0.07f + z);
            mouseketool[10].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.17f + x, -0.25f + y, 0.07f + z);
            mouseketool[11].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.2f + x, -0.33f + y, 0.07f + z);
            mouseketool[11].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.01f + x, 0.32f + y, 0.07f + z);
            mouseketool[12].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.2f + x, 0.32f + y, 0.07f + z);
            mouseketool[12].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.21f + x, 0.31f + y, 0.07f + z);
            mouseketool[12].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.3f + x, -0.15f + y, 0.07f + z);
            mouseketool[12].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.1f + x, -0.1f + y, 0.07f + z);
            mouseketool[12].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // telinga kiri
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(-0.4f + x, 0.58f + y, 0.0f + z);
            mouseketool[13].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(-0.4f + x, 0.58f + y, 0.0f + z);
            mouseketool[14].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.4f + x, 0.58f + y, 0.05f + z);
            mouseketool[15].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.4f + x, 0.58f + y, 0.055f + z);
            mouseketool[16].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.4f + x, 0.58f + y, 0.06f + z);
            mouseketool[17].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // telinga kanan
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.4f + x, 0.58f + y, 0.0f + z);
            mouseketool[13].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.4f + x, 0.58f + y, 0.0f + z);
            mouseketool[14].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.4f + x, 0.58f + y, 0.05f + z);
            mouseketool[15].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.4f + x, 0.58f + y, 0.055f + z);
            mouseketool[16].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.4f + x, 0.58f + y, 0.06f + z);
            mouseketool[17].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
    }
}
