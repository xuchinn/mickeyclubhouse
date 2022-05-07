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
    internal class Clubhouse: Asset3d
    {
        float time_passed = 0;
        List<Asset3d> objectList = new List<Asset3d>();
        float degr_head = 0;
        float degr_body = 0;
        bool reverse = false;

        public Clubhouse() { }

        public void initObjects()
        {

            var leher = new Asset3d();
            leher.createCylinder(0.0f, 0.0f, 0.5f, 0.12f, 1.4f);
            leher.setColor((0.0f, 0.0f, 0.0f));
            objectList.Add(leher);

            var head = new Asset3d();
            head.createEllipsoid(0.0f, 0.0f, 0.0f, 0.6f, 0.6f, 0.6f, 72, 24);
            head.setColor((0.0f, 0.0f, 0.0f));
            objectList.Add(head);

            var ear_l = new Asset3d();
            ear_l.createEllipsoid(0.0f, 0.0f, 0.0f, 0.3f, 0.3f, 0.3f, 72, 24);
            ear_l.setColor((0.0f, 0.0f, 0.0f));
            objectList.Add(ear_l);

            var ear_r = new Asset3d();
            ear_r.createEllipsoid(0.0f, 0.0f, 0.0f, 0.3f, 0.3f, 0.3f, 72, 24);
            ear_r.setColor((0.0f, 0.0f, 0.0f));
            objectList.Add(ear_r);

            var badan = new Asset3d();
            badan.createHemisphere(0.65f, 0.65f, 0.65f, 0.0f, 0.0f, 0.0f);
            badan.setColor((0.9f, 0.0f, 0.15f));
            objectList.Add(badan);

            var baju_kiri = new Asset3d();
            baju_kiri.createEllipsoid(0.0f, 0.0f, 1.0f, 0.07f, 0.12f, 0.07f, 72, 24);
            baju_kiri.setColor((1.0f, 1.0f, 1.0f));
            objectList.Add(baju_kiri);

            var baju_kanan = new Asset3d();
            baju_kanan.createEllipsoid(0.0f, 0.0f, 1.0f, 0.07f, 0.12f, 0.07f, 72, 24);
            baju_kanan.setColor((1.0f, 1.0f, 1.0f));
            objectList.Add(baju_kanan);

            var kaki = new Asset3d();
            //z     y     x
            kaki.createCylinder(0.0f, -1.1f, 0.55f, 0.15f, 1.6f);
            kaki.setColor((0.0f, 0.0f, 0.0f));
            objectList.Add(kaki);

            var sepatu1 = new Asset3d();
            sepatu1.createCylinder(0.0f, -1.1f, 0.7f, 0.18f, 0.5f);
            sepatu1.setColor((1.0f, 1.0f, 0.15f));
            objectList.Add(sepatu1);

            var sepatu2 = new Asset3d();
            sepatu2.createHemisphere(0.28f, 0.25f, 0.23f, 0.0f, -0.0f, 0.0f);
            sepatu2.setColor((1.0f, 1.0f, 0.15f));
            objectList.Add(sepatu2);

            var sepatu4 = new Asset3d();
            sepatu4.createHemisphere(0.2f, 0.28f, 0.23f, 0.0f, -0.0f, 0.0f);
            sepatu4.setColor((1.0f, 1.0f, 0.15f));
            objectList.Add(sepatu4);

            var socks = new Asset3d();
            socks.createTorus(0.0f, 0.0f, 0.0f, 0.17f, 0.03f);
            socks.Rotate((0.0f, 0.0f, 0.0f), (0.0f, 1.0f, 0.0f), 90f);
            socks.setColor((1.0f, 1.0f, 0.15f));
            objectList.Add(socks);

            var slide = new Asset3d();
            slide.setColor((0.31f, 0.51f, 1.0f));
            slide.createCylinder(-0.4f, -0.8f, 0.0f, 0.1f, 0.5f);
            objectList.Add(slide);
            slide = new Asset3d();
            slide.setColor((0.19f, 0.34f, 0.85f));
            slide.createTorus(-0.4f, -0.8f, 0.0f, 0.1f, 0.008f);
            objectList.Add(slide);

            var tail = new Asset3d();
            tail.setColor((0.0f, 0.0f, 0.0f));
            tail.AddCoordinates(0.0f, 0.0f, -0.65f);
            tail.AddCoordinates(-0.3f, 0.0f, -0.8f);
            tail.AddCoordinates(0.2f, 0.0f, -0.95f);
            tail.AddCoordinates(0.0f, 0.0f, -1.2f);
            tail.Bezier3d();
            objectList.Add(tail);

            var door = new Asset3d();
            door.setColor((1.0f, 1.0f, 1.0f));
            door.createHalfTorus(1.0f, 0.0f, 0.0f, 0.1f, 0.5f, 0.01f);
            door.Rotate((1.0f, 0.0f, 0.0f), (0.0f, 1.0f, 0.0f), 90f);
            objectList.Add(door);

            var carpet = new Asset3d();
            carpet.setColor((0.9f, 0.0f, 0.15f));
            carpet.createFilledCylinder(0.2f, 0.0f, 0.0f, 0.1f, 0.15f);
            objectList.Add(carpet);

            var window = new Asset3d();
            window.setColor((0.18f, 0.78f, 0.98f));
            window.createFilledCylinder(0.2f, 0.2f, 0.0f, 0.05f, 0.1f);
            window.Rotate((0.2f, 0.2f, 0.0f), (0.0f, 0.0f, 1.0f), 90f);
            objectList.Add(window);

            var snow = new Asset3d();
            snow.setColor((1.0f, 1.0f, 1.0f));
            snow.createEllipsoid(0.0f, 0.0f, 0.0f, 0.01f, 0.01f, 0.01f, 72, 24);
            objectList.Add(snow);

        }

        public void load()
        {
            foreach (Asset3d i in objectList)
            {
                i.load(Constants.path, 0);
            }
        }

        public void renderObjects(Camera _camera, float scale, FrameEventArgs args, float x, float y, float z)
        {
            if (reverse)
            {
                time_passed -= (float)args.Time * 3;
            }
            else 
            {
                time_passed += (float)args.Time * 3;
            }
            Console.WriteLine(reverse + " " + time_passed+" "+degr_head);

            Matrix4 temp = Matrix4.Identity;
            if (time_passed < 0)
            {
                reverse = false;
            }
            if (time_passed <= 5)
            {
                degr_body = 180f * time_passed / 5;
                temp = Matrix4.Identity; 
                temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
                temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degr_body));
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.1f + y, 0.0f + z);
                objectList[4].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //badan
                
            }
            else if (time_passed > 5)
            {
                temp = Matrix4.Identity; 
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.1f + y, 0.0f + z);
                objectList[4].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //badan


                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.2f + y, 0.0f + z);
                objectList[14].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //tail
            }
            
            if (time_passed > 5 && time_passed <= 15)
            {
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(0.0f + x, (float)(1.4f * (time_passed - 5) / 10) + y, 0.0f + z);
                objectList[1].render(temp, scale * (time_passed - 5) / 10, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //head

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
                temp = temp * Matrix4.CreateTranslation(-0.12f + x, 0.37f + y, 0.53f * (time_passed - 5) / 10 + z);
                objectList[5].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //kancing kiri

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
                temp = temp * Matrix4.CreateTranslation(0.12f + x, 0.37f + y, 0.53f * (time_passed - 5) / 10 + z);
                objectList[6].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //kancing kanan

                if (time_passed > 10)
                {
                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
                    temp = temp * Matrix4.CreateTranslation(0.0f + x, 1.4f + y, 0.0f + z);
                    objectList[0].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //leher
                }
            }
            else if(time_passed > 15)
            {
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 1.4f + y, 0.0f + z);
                objectList[1].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //head

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 1.4f + y, 0.0f + z);
                objectList[0].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //leher

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
                temp = temp * Matrix4.CreateTranslation(-0.12f + x, 0.37f + y, 0.53f + z);
                objectList[5].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //kancing kiri

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
                temp = temp * Matrix4.CreateTranslation(0.12f + x, 0.37f + y, 0.53f + z);
                objectList[6].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //kancing kanan
            }

            if (time_passed > 15 && time_passed <= 20)
            {
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation((0.6f + 0.3f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)) * (time_passed - 15) / 5f + x, 1.4f + (0.6f + 0.3f) * (time_passed - 15) / 5f * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)) + y, 0.0f + z);
                objectList[2].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //left ear

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(-(0.6f + 0.3f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)) * (time_passed - 15) / 5f + x, 1.4f + (0.6f + 0.3f) * (time_passed - 15) / 5f * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)) + y, 0.0f + z);
                objectList[3].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //right ear
            }
            else if(time_passed > 20)
            {
                if (time_passed < 27)
                {
                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateTranslation((0.6f + 0.3f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)) + x, 1.4f + (0.6f + 0.3f) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)) + y, 0.0f + z);
                    objectList[2].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateTranslation(-(0.6f + 0.3f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)) + x, 1.4f + (0.6f + 0.3f) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)) + y, 0.0f + z);
                    objectList[3].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                }
            }

            if(time_passed > 20 && time_passed <= 25)
            {
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(-1.0f + (time_passed - 20) / 5 + x, 1.4f + y, 0.0f + z);
                objectList[7].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //kaki

                //sepatu
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(-1.0f + (time_passed - 20) / 5 + x, 1.4f + y, 0.0f + z);
                objectList[8].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation((time_passed - 20) / 5 + x, 0.6f + y, 0.0f + z);
                objectList[9].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation((time_passed - 20) / 5 + x, 0.3f + y, 0.0f + z);
                objectList[10].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(-1f + (time_passed - 20) / 5 + x, 0.0f + y, 0.0f + z);
                objectList[15].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //door

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(-0.2f + (time_passed - 20) / 5 + x, 0.0f + y, 0.0f + z);
                objectList[16].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //carpet
            }
            else if(time_passed > 25)
            {
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 1.4f + y, 0.0f + z);
                objectList[7].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //kaki

                //sepatu
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 1.4f + y, 0.0f + z);
                objectList[8].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(1.0f + x, 0.6f + y, 0.0f + z);
                objectList[9].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(90f));
                temp = temp * Matrix4.CreateTranslation(1.0f + x, 0.3f + y, 0.0f + z);
                objectList[10].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(0.8f + x, 0.3f + y, 0.0f + z);
                objectList[11].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.0f + z);
                objectList[15].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //door

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(0.8f + x, 0.1f + y, 0.0f + z);
                objectList[16].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix()); //carpet
            }

            if (time_passed > 25 && time_passed <= 27)
            {
                //slide
                temp = Matrix4.Identity;
                float deg = -90f;
                int amount = 50;
                for (int i = 0; i < amount; i++)
                {
                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(deg - (i * deg / 50)));
                    temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-135f));
                    temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(180f));
                    temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-45f + 25 * (time_passed - 25) / 2));
                    temp = temp * Matrix4.CreateTranslation(-0.6f * (time_passed - 25) / 2 + x, -0.2f + y, -0.2f + z);
                    objectList[12].render(temp, scale * (time_passed - 25) / 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                    if (i % 10 == 0)
                    {
                        objectList[13].render(temp, scale * (time_passed - 25) / 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                    }
                }
            }
            else if (time_passed > 27)
            {
                //slide
                temp = Matrix4.Identity;
                float deg = -90f;
                int amount = 50;
                for (int i = 0; i < amount; i++)
                {
                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(deg - (i * deg / 50)));
                    temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-135f));
                    temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(180f));
                    temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-20f));
                    temp = temp * Matrix4.CreateTranslation(-0.6f + x, -0.2f + y, -0.2f + z);
                    objectList[12].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                    if (i % 10 == 0)
                    {
                        objectList[13].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                    }
                }
            }
            if (time_passed > 27)
            {
                degr_head += MathHelper.DegreesToRadians(1f);

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation((0.6f + 0.3f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)) + x, 1.4f + (0.6f + 0.3f) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)) + y, 0.0f + z);
                temp = temp * Matrix4.CreateRotationY(degr_head);
                objectList[2].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                temp = Matrix4.Identity;
                temp = temp * Matrix4.CreateTranslation(-(0.6f + 0.3f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)) + x, 1.4f + (0.6f + 0.3f) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)) + y, 0.0f + z);
                temp = temp * Matrix4.CreateRotationY(degr_head);
                objectList[3].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

                if(degr_head > MathHelper.Pi)
                {
                    degr_head = 0;
                    reverse = true;
                }
            }
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.8f + x, 0.45f + y, 0.0f + z);
            objectList[17].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

        }

    }
}
