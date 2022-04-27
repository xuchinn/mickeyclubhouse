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
    internal class Mickey : Asset3d
    {
        List<Asset3d> mickey_mouse = new List<Asset3d>();
        Vector3 black = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 white = new Vector3(1.0f, 1.0f, 1.0f);
        Vector3 beige = new Vector3(0.984f, 0.8f, 0.737f);
        Vector3 red = new Vector3(0.639f, 0.023f, 0.101f);
        Vector3 yellow = new Vector3(0.988f, 0.835f, 0.160f);
        float lefteye = -0.055f;
        float righteye = 0.055f;
        bool balik_kiri = true;
        bool balik_kanan = false;
        //float deg_right_leg = 0f;
        //float deg_right_ankle = 0f;
        float deg_right_heels = 0f;
        float deg_right_front = 0f;
        //bool right_leg_up = true;
        //bool right_ankle = true;
        bool right_heels = true;
        bool right_front = true;
        float deg_left_heels = 0f;
        float deg_left_front = 0f;
        bool left_heels = true;
        bool left_front = true;

        public Mickey()
        {
        }
        public void setObjects()
        {
            var head = new Asset3d();
            head.createEllipsoid(0.0f, 0.0f, 0.0f, 0.45f, 0.45f, 0.45f, 72, 24);
            head.setColor(black);
            mickey_mouse.Add(head);

            var left_ear = new Asset3d();
            left_ear.createEllipsoid(0.0f, 0.0f, 0.0f, 0.2f, 0.2f, 0.2f, 72, 24);
            left_ear.setColor(black);
            mickey_mouse.Add(left_ear);
            mickey_mouse.Add(left_ear);

            var top_face = new Asset3d();
            top_face.createEllipsoid(0.0f, 0.0f, 1.0f, 0.14f, 0.19f, 0.045f, 72, 24);
            top_face.setColor(beige);
            mickey_mouse.Add(top_face); // left
            mickey_mouse.Add(top_face); // right

            var bottom_face = new Asset3d();
            bottom_face.createEllipsoid(0.0f, 0.0f, 1.0f, 0.25f, 0.17f, 0.045f, 72, 24);
            bottom_face.setColor(beige);
            mickey_mouse.Add(bottom_face);

            var eye1 = new Asset3d();
            eye1.createEllipsoid(0.0f, 0.0f, 2.0f, 0.05f, 0.15f, 0.035f, 72, 24);
            eye1.setColor(white);
            mickey_mouse.Add(eye1);

            var eye2 = new Asset3d();
            eye2.createEllipsoid(0.0f, 0.0f, 3.0f, 0.02f, 0.035f, 0.025f, 72, 24);
            eye2.setColor(black);
            mickey_mouse.Add(eye2);

            // right
            mickey_mouse.Add(eye1);
            mickey_mouse.Add(eye2);

            var nose_bridge = new Asset3d();
            nose_bridge.createCone(0.0f, 0.0f, 2.0f, 0.05f, 0.05f, 0.07f);
            nose_bridge.setColor(beige);
            mickey_mouse.Add(nose_bridge);
             
            var body = new Asset3d();
            body.createCylinder(0.0f, 0.0f, 0.0f, 0.3f, 1.7f);
            body.setColor(black);
            mickey_mouse.Add(body);

            var bottom = new Asset3d();
            bottom.createEllipsoid(0.0f, 0.0f, 0.0f, 0.35f, 0.3f, 0.35f, 72, 24);
            bottom.setColor(red);
            mickey_mouse.Add(bottom);

            var button = new Asset3d();
            button.createEllipsoid(0.0f, 0.0f, 1.0f, 0.05f, 0.05f, 0.01f, 72, 24);
            button.setColor(white);
            mickey_mouse.Add(button);
            mickey_mouse.Add(button);

            var hand = new Asset3d();
            hand.createEllipsoid(0.0f, 0.0f, 0.0f, 0.07f, 0.4f, 0.08f, 72, 24);
            hand.setColor(black);
            mickey_mouse.Add(hand);
            mickey_mouse.Add(hand);

            var pants = new Asset3d();
            pants.createCylinder(0.0f, 0.0f, 0.0f, 0.13f, 0.8f);
            pants.setColor(red);
            mickey_mouse.Add(pants);
            mickey_mouse.Add(pants);

            var leg = new Asset3d();
            leg.createEllipsoid(0.0f, 0.0f, 0.0f, 0.07f, 0.35f, 0.08f, 72, 24);
            leg.setColor(black);
            mickey_mouse.Add(leg);
            mickey_mouse.Add(leg);

            var ankle = new Asset3d();
            ankle.createTorus(0.0f, 0.0f, 0.0f, 0.07f, 0.03f);
            ankle.setColor(yellow);
            mickey_mouse.Add(ankle);
            mickey_mouse.Add(ankle);

            var shoes_heels = new Asset3d();
            shoes_heels.createHemisphere(0.1f, 0.1f, 0.15f, 0.0f, 0.0f, 0.0f);
            shoes_heels.setColor(yellow);
            mickey_mouse.Add(shoes_heels);
            mickey_mouse.Add(shoes_heels);

            var shoes_front = new Asset3d();
            shoes_front.createHemisphere(0.1f, 0.1f, 0.15f, 0.0f, 0.0f, 0.0f);
            shoes_front.setColor(yellow);
            mickey_mouse.Add(shoes_front);
            mickey_mouse.Add(shoes_front);

            var wrist = new Asset3d();
            wrist.createTorus(0.0f, 0.0f, 0.0f, 0.05f, 0.02f);
            wrist.setColor(white);
            mickey_mouse.Add(wrist);
            mickey_mouse.Add(wrist);

            var palm = new Asset3d();
            palm.createEllipsoid(0.0f, 0.0f, 0.0f, 0.07f, 0.07f, 0.05f, 72, 24);
            palm.setColor(white);
            mickey_mouse.Add(palm);
            mickey_mouse.Add(palm);

            var nose = new Asset3d();
            nose.createEllipsoid(0.0f, 0.0f, 3.0f, 0.03f, 0.03f, 0.03f, 72, 24);
            nose.setColor(black);
            mickey_mouse.Add(nose);

            var fingers = new Asset3d();
            fingers.createEllipsoid(0.0f, 0.0f, 0.0f, 0.02f, 0.07f, 0.02f, 72, 24);
            fingers.setColor(white);
            for (int i = 0; i < 8; i++)
            {
                mickey_mouse.Add(fingers);
            };

            var mouth = new Asset3d();
            mouth.AddCoordinates(-0.2f, -0.15f, 0.45f);
            mouth.AddCoordinates(-0.1f, -0.25f, 0.45f);
            mouth.AddCoordinates(0.1f, -0.25f, 0.45f);
            mouth.AddCoordinates(0.2f, -0.15f, 0.45f);
            mouth.setColor(black);
            mouth.Bezier3d();
            mickey_mouse.Add(mouth);

            var tail = new Asset3d();
            tail.AddCoordinates(0.0f, -0.8f, -0.4f);
            tail.AddCoordinates(0.0f, -0.9f, -0.45f);
            tail.AddCoordinates(0.0f, -0.5f, -0.45f);
            tail.AddCoordinates(0.0f, -0.2f, -0.6f);
            tail.setColor(black);
            tail.Bezier3d();
            mickey_mouse.Add(tail);
        }
        public void loadObjects()
        {
            setObjects();
            foreach (Asset3d _object in mickey_mouse)
            {
                _object.load(Constants.path, 0);
            }
        }
        public void renderObjects(FrameEventArgs args, Camera _camera, float scaling, float x, float y, float z)
        {
            Matrix4 temp = Matrix4.Identity;

            // head
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.0f + z);
            mickey_mouse[0].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // left_ear
            temp = Matrix4.Identity;
            //temp = temp * Matrix4.CreateTranslation(-(0.5f + 0.14f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)), (0.5f + 0.14f) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)), 0.0f);
            temp = temp * Matrix4.CreateTranslation(-0.43f + x, 0.47f + y, 0.0f + z);
            mickey_mouse[1].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            
            // right_ear
            temp = Matrix4.Identity;
            //temp = temp * Matrix4.CreateTranslation((0.5f + 0.14f) * (float)MathHelper.Cos(MathHelper.DegreesToRadians(45f)), (0.5f + 0.14f) * (float)MathHelper.Sin(MathHelper.DegreesToRadians(45f)), 0.0f);
            temp = temp * Matrix4.CreateTranslation(0.43f + x, 0.47f + y, 0.0f + z);
            mickey_mouse[2].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // left_face
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
            temp = temp * Matrix4.CreateTranslation(-0.05f + x, 0.1f + y, 0.4f + z);
            mickey_mouse[3].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // right_face
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
            temp = temp * Matrix4.CreateTranslation(0.05f + x, 0.1f + y, 0.4f + z);
            mickey_mouse[4].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // bottom_face
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(15f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, -0.15f + y, 0.4f + z);
            mickey_mouse[5].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // left_eye1
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
            temp = temp * Matrix4.CreateTranslation(-0.06f + x, 0.1f + y, 0.45f + z);
            mickey_mouse[6].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            // left_eye2
            temp = Matrix4.Identity;
            if (balik_kiri == true)
            {
                lefteye += 0.0001f;
                if (lefteye >= -0.047)
                {
                    balik_kiri = false;
                }
            }
            else
            {
                lefteye -= 0.0001f;
                if (lefteye <= -0.063)
                {
                    balik_kiri = true;
                }
            }
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.5f + z);
            temp = temp * Matrix4.CreateTranslation(lefteye, 0.0f, 0.0f);
            mickey_mouse[7].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // right_eye1
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
            temp = temp * Matrix4.CreateTranslation(0.06f + x, 0.1f + y, 0.45f + z);
            mickey_mouse[8].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // right_eye2
            temp = Matrix4.Identity;
            if(balik_kanan == false)
            {
                righteye += 0.0001f;
                if(righteye >= 0.063)
                {
                    balik_kanan = true;
                }
            }
            else
            {
                righteye -= 0.0001f;
                if(righteye <= 0.047)
                {
                    balik_kanan = false;
                }
            }
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-15f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0f + y, 0.5f + z);
            temp = temp * Matrix4.CreateTranslation(righteye, 0.0f, 0.0f);
            mickey_mouse[9].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // nose_bridge
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(5f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.075f + y, -1.45f + z);
            mickey_mouse[10].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // body
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, -0.32f + y, 0.0f + z);
            mickey_mouse[11].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // bottom
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, -0.8f + y, 0f + z);
            mickey_mouse[12].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // button
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-5f));
            temp = temp * Matrix4.CreateTranslation(-0.06f + x, -0.8f + y, 0.35f + z);
            mickey_mouse[13].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-5f));
            temp = temp * Matrix4.CreateTranslation(0.06f + x, -0.8f + y, 0.35f + z);
            mickey_mouse[14].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // hand
            temp = Matrix4.Identity;
            //if (naik == false)
            //{
            //    deg_kanan += 0.2f;
            //    if(deg_kanan >= 150f)
            //    {
            //        naik = true;
            //    }
            //}
            //else
            //{
            //    deg_kanan -= 0.2f;
            //    if (deg_kanan <= 130f)
            //    {
            //        naik = false;
            //    }
            //}
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(130f));
            temp = temp * Matrix4.CreateTranslation(0.45f + x, -0.35f + y, 0.0f + z);
            mickey_mouse[15].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-130f));
            temp = temp * Matrix4.CreateTranslation(-0.45f + x, -0.35f + y, 0.0f + z);
            mickey_mouse[16].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // pants
            temp = Matrix4.Identity;
            temp = temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-8f));
            temp = temp * Matrix4.CreateTranslation(-0.15f + x, -1f + y, 0.0f + z);
            mickey_mouse[17].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(8f));
            temp = temp * Matrix4.CreateTranslation(0.15f + x, -1.0f + y, 0.0f + z);
            mickey_mouse[18].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // leg
            temp = Matrix4.Identity;
            //if(right_leg_up == true)
            //{
            //    deg_right_leg += 0.5f;
            //    if(deg_right_leg >= 15f)
            //    {
            //        right_leg_up = false;
            //    }
            //}
            //else
            //{
            //    deg_right_leg -= 0.5f;
            //    if (deg_right_leg <= 0f)
            //    {
            //        right_leg_up = true;
            //    }
            //}
            //temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(deg_right_leg));
            temp = temp * Matrix4.CreateTranslation(0.15f + x, -1.2f + y, 0.0f + z);
            mickey_mouse[19].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(-0.15f + x, -1.2f + y, 0.0f + z);
            mickey_mouse[20].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // ankle
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(-0.15f + x, -1.5f + y, 0.0f + z);
            mickey_mouse[21].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            //if (right_ankle == true)
            //{
            //    deg_right_ankle += 0.5f;
            //    if (deg_right_ankle >= 15f)
            //    {
            //        right_ankle = false;
            //    }
            //}
            //else
            //{
            //    deg_right_ankle -= 0.5f;
            //    if (deg_right_ankle <= 0f)
            //    {
            //        right_ankle = true;
            //    }
            //}
            //temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(deg_right_ankle));
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateTranslation(0.15f + x, -1.5f + y, 0.0f + z);
            mickey_mouse[22].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // shoes_heels
            temp = Matrix4.Identity;
            if (right_heels == true)
            {
                deg_right_heels += 1.5f;
                if (deg_right_heels >= 20f)
                {
                    right_heels = false;
                }
            }
            else
            {
                deg_right_heels -= 1.5f;
                if (deg_right_heels <= -20f)
                {
                    right_heels = true;
                }
            }
            temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(deg_right_heels));
            temp = temp * Matrix4.CreateTranslation(0.15f + x, -1.6f + y, 0.0f + z);
            mickey_mouse[23].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            if (left_heels == true)
            {
                deg_left_heels += 1.5f;
                if (deg_left_heels >= 20f)
                {
                    left_heels = false;
                }
            }
            else
            {
                deg_left_heels -= 1.5f;
                if (deg_left_heels <= -20f)
                {
                    left_heels = true;
                }
            }
            temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(deg_left_heels));
            temp = temp * Matrix4.CreateTranslation(-0.15f + x, -1.6f + y, 0.0f + z);
            mickey_mouse[24].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // shoes_front
            temp = Matrix4.Identity;
            if (right_front == true)
            {
                deg_right_front += 1.5f;
                if (deg_right_front >= 20f)
                {
                    right_front = false;
                }
            }
            else
            {
                deg_right_front -= 1.5f;
                if (deg_right_front <= -20f)
                {
                    right_front = true;
                }
            }
            temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(deg_right_front));
            temp = temp * Matrix4.CreateTranslation(0.15f + x, -1.6f + y, 0.15f + z);
            mickey_mouse[25].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            if (left_front == true)
            {
                deg_left_front += 1.5f;
                if (deg_left_front >= 20f)
                {
                    left_front = false;
                }
            }
            else
            {
                deg_left_front -= 1.5f;
                if (deg_left_front <= -20f)
                {
                    left_front = true;
                }
            }
            temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(deg_left_front));
            temp = temp * Matrix4.CreateTranslation(-0.15f + x, -1.6f + y, 0.15f + z);
            mickey_mouse[26].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // wrist
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-45f));
            temp = temp * Matrix4.CreateTranslation(0.7f + x, -0.125f + y, 0.0f + z);
            mickey_mouse[27].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(45f));
            temp = temp * Matrix4.CreateTranslation(-0.7f + x, -0.125f + y, 0.0f + z);
            mickey_mouse[28].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //palm
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-45f));
            temp = temp * Matrix4.CreateTranslation(0.725f + x, -0.1f + y, 0.0f + z);
            mickey_mouse[29].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-45f));
            temp = temp * Matrix4.CreateTranslation(-0.725f + x, -0.1f + y, 0.0f + z);
            mickey_mouse[30].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // nose
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, -0.089f + y, 0.55f + z);
            mickey_mouse[31].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // fingers (32, 33, 34, 35 || 36, 37, 38, 39)
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(30f));
            temp = temp * Matrix4.CreateTranslation(0.67f + x, -0.015f + y, 0.0f + z);
            mickey_mouse[32].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0f));
            temp = temp * Matrix4.CreateTranslation(0.74f + x, -0.01f + y, 0.0f + z);
            mickey_mouse[33].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-55f));
            temp = temp * Matrix4.CreateTranslation(0.79f + x, -0.06f + y, 0.0f + z);
            mickey_mouse[34].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-85f));
            temp = temp * Matrix4.CreateTranslation(0.78f + x, -0.122f + y, 0.0f + z);
            mickey_mouse[35].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-30f));
            temp = temp * Matrix4.CreateTranslation(-0.67f + x, -0.015f + y, 0.0f + z);
            mickey_mouse[36].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(0f));
            temp = temp * Matrix4.CreateTranslation(-0.74f + x, -0.01f + y, 0.0f + z);
            mickey_mouse[37].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(55f));
            temp = temp * Matrix4.CreateTranslation(-0.79f + x, -0.06f + y, 0.0f + z);
            mickey_mouse[38].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(85f));
            temp = temp * Matrix4.CreateTranslation(-0.78f + x, -0.122f + y, 0.0f + z);
            mickey_mouse[39].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // mouth
            temp = Matrix4.Identity ;
            temp = temp * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(15f));
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.1f + y, 0.043f + z);
            mickey_mouse[40].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            
            // tail
            temp = Matrix4.Identity;
            temp = temp * Matrix4.CreateTranslation(0.0f + x, 0.0f + y, 0.05f + z);
            mickey_mouse[41].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
    }
}
