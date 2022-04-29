using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace TugasProject
{
    class Balloon : Asset3d
    {
        //Asset2d[] _object = new Asset2d[5];
        List<Asset3d> handObject = new List<Asset3d>();
        List<Asset3d> tubeObject = new List<Asset3d>();
        List<Asset3d> basketObject = new List<Asset3d>();
        Asset3d partition;

        double _time;

        float maxY = 3f;
        float minY = 0f;
        float curY = -0.1f;

        float maxFly = 3.5f;
        float minFly = 2.5f;
        float curFly = 3f;

        bool mentok = false; /*true = mentok bawah, false = mentok atas*/
        bool mentokFly = false;

        bool muter = false;
        float degr = -3.1f;

        static class Constants
        {
            public const string path = "../../../Shaders/";
        }

        public void loadObjects()
        {
            //TODO UNTUK ASSET 3D
            createHand();
            foreach (Asset3d obj in handObject)
            {
                obj.load(Constants.path, 0);
            }

            createBasket();
            foreach (Asset3d obj in basketObject)
            {
                obj.load(Constants.path, 0);
            }

            createTube();
            foreach (Asset3d obj in tubeObject)
            {
                obj.load(Constants.path, 0);
            }
        }

        protected void createHand()
        {
            Vector3 handObjectColor = new Vector3(0.929f, 0.925f, 0.890f);

            // PALM
            partition = new Asset3d(handObjectColor);
            partition.createEllipsoid(0, 0, 0, 0.45f, 0.45f, 0.35f, 72, 24);
            handObject.Add(partition);

            // FINGER 1 - Jempol
            partition = new Asset3d(handObjectColor);
            partition.createEllipsoid(0, 0, 0, 0.15f, 0.37f, 0.1f, 72, 24);
            partition.Rotate((-0.5f, -0.3f, 0), (0, 0, 1), 70f);
            handObject.Add(partition);
            // FINGER 2
            partition = new Asset3d(handObjectColor);
            partition.createEllipsoid(0, 0, 0, 0.15f, 0.37f, 0.1f, 72, 24);
            partition.Rotate((-0.1f, 0, 2f), (0, 0, 1), 30f);
            handObject.Add(partition);
            // FINGER 3
            partition = new Asset3d(handObjectColor);
            partition.createEllipsoid(0, 0, 0, 0.15f, 0.37f, 0.1f, 72, 24);
            partition.Rotate((0.05f, 0.32f, 0), (0, 0, 1), -10f);
            handObject.Add(partition);
            // FINGER 4
            partition = new Asset3d(handObjectColor);
            partition.createEllipsoid(0, 0, 0, 0.15f, 0.37f, 0.1f, 72, 24);
            partition.Rotate((0.21f, 0.3f, 0), (0, 0, 1), -50f);
            handObject.Add(partition);

            //DONUT
            partition = new Asset3d(handObjectColor);
            partition.createTorus(0, 0, 0, 0.3f, 0.08f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 90f);
            handObject.Add(partition);

            // Bezier
            partition = new Asset3d(new Vector3(0f, 0f, 0f));
            partition.AddCoordinates(0, 0, 0);
            partition.AddCoordinates(0.2f, -0.2f, 0);
            partition.AddCoordinates(-0.2f, -0.2f, 0);
            partition.AddCoordinates(0, 0, 0);
            partition.Bezier3d();
            handObject.Add(partition);
        }
        protected void createBasket()
        {
            var bowlColor = new Vector3(0.615f, 0.203f, 0.203f);
            var ropeColor = new Vector3(0.937f, 0.854f, 0.180f);

            // BOWL
            partition = new Asset3d(bowlColor);
            partition.createEllipticParaboloid(0.3f, 0.3f, 0.3f, 0, 0, 0);
            partition.Rotate((0, 0, 0), (1, 0, 0), -90f);
            basketObject.Add(partition);

            // UPPER BOWL
            partition = new Asset3d(bowlColor);
            partition.createCylinder(0, 0, 0, 0.3f, 0.3f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 90f);
            basketObject.Add(partition);

            // ROPE - Kanan
            partition = new Asset3d(ropeColor);
            partition.createCylinder(0, 0, 0, 0.01f, 80f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 90f);
            partition.Rotate((0, 0, 0), (0, 0, 1), -5f);
            basketObject.Add(partition);
            // ROPE - Depan
            partition = new Asset3d(ropeColor);
            partition.createCylinder(0, 0, 0, 0.01f, 80f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 85f);
            basketObject.Add(partition);
            // ROPE - Kiri
            partition = new Asset3d(ropeColor);
            partition.createCylinder(0, 0, 0, 0.01f, 80f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 95f);
            basketObject.Add(partition);
            // ROPE - Belakang
            partition = new Asset3d(ropeColor);
            partition.createCylinder(0, 0, 0, 0.01f, 80f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 90f);
            partition.Rotate((0, 0, 0), (0, 0, 1), 5f);
            basketObject.Add(partition);
            // ROPE - Donut
            partition = new Asset3d(ropeColor);
            partition.createTorus(0, 0, 0, 0.3f, 0.01f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 90f);
            basketObject.Add(partition);
        }
        protected void createTube()
        {
            Vector3 tubeObjectColor = new Vector3(0.16f, 0.16f, 0.16f);

            // TUBE
            partition = new Asset3d(tubeObjectColor);
            partition.createCylinder(0, 0, 0, 0.36f, 3f);
            partition.Rotate((0, 0, 0), (1, 0, 0), 90f);
            tubeObject.Add(partition);


            // PLANE
            partition = new Asset3d(new Vector3(0.419f, 0.866f, 0.211f));
            partition.createEllipsoid(2f, 0.001f, 2f, 0, 0, 0, 72, 24);
            tubeObject.Add(partition);
        }

        public void renderObjects(FrameEventArgs args, Camera _camera, float scaling, float x,
            float y, float z)
        {
            Matrix4 temp = Matrix4.Identity;

            renderHand(temp, args, _camera, scaling, x, y, z);
            renderBasket(temp, args, _camera, scaling, x, y, z);
            renderTube(temp, _camera, scaling, x, y, z);
        }

        protected void renderHand(Matrix4 temp, FrameEventArgs args, Camera _camera, float scaling, float x,
            float y, float z)
        {
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, 0 + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[0].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //FINGERS
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -0.2f + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[1].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.25f - 1f + x, 0.54f + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[2].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.28f - 1f + x, 0.6f + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[3].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.75f - 1f + x, 0 + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[4].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //DONUT
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -0.38f + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[5].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // BEZIER
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -0.45f + y, 0 + z);
            temp = translateObject(temp, args);
            handObject[6].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
        protected void renderBasket(Matrix4 temp, FrameEventArgs args, Camera _camera, float scaling, float x,
            float y, float z)
        {
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -1.49f + y, 0 + z);
            temp = translateObject(temp, args);
            basketObject[0].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -1.1f + y, 0 + z);
            temp = translateObject(temp, args);
            basketObject[1].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            // ROPE
            temp = Matrix4.Identity * Matrix4.CreateTranslation(0.35f - 1f + x, -0.4f + y, 0 + z);
            temp = translateObject(temp, args);
            basketObject[2].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -0.4f + y, -0.35f + z);
            temp = translateObject(temp, args);
            basketObject[3].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -0.4f + y, 0.35f + z);
            temp = translateObject(temp, args);
            basketObject[4].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-0.35f - 1f + x, -0.4f + y, 0 + z);
            temp = translateObject(temp, args);
            basketObject[5].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -1.13f + y, 0 + z);
            temp = translateObject(temp, args);
            basketObject[6].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }
        protected void renderTube(Matrix4 temp, Camera _camera, float scaling, float x,
            float y, float z)
        {
            // TUBE
            temp = Matrix4.Identity * Matrix4.CreateTranslation(-1f + x, -0.42f + y, 0 + z);
            tubeObject[0].render(temp, scaling, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //// PLANE
            //temp = Matrix4.Identity * Matrix4.CreateTranslation(0, -1.5f, 0);
            //tubeObject[1].render(_time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
        }

        protected Matrix4 translateObject(Matrix4 temp, FrameEventArgs args)
        {
            if (curY <= minY || mentok == false)
            {
                curY += 0.005f;
                temp *= Matrix4.CreateTranslation(0, curY, 0);
                mentok = false;
                if (curY >= maxY)
                {
                    mentok = true;
                    muter = true;
                }
            }
            else if (curY >= maxY || mentok == true)
            {
                if (muter == true)
                {
                    temp = rotateObject(temp);
                }
                else
                {
                    curY -= 0.005f;
                    temp *= Matrix4.CreateTranslation(0, curY, 0);
                    if (curY <= minY)
                    {
                        mentok = false;
                    }
                }
            }
            return temp;
        }

        protected Matrix4 rotateObject(Matrix4 temp)
        {
            temp *= Matrix4.CreateTranslation(3.6f, 0, 0);
            degr += MathHelper.DegreesToRadians(0.1f);
            temp *= Matrix4.CreateRotationY(degr);
            if (degr >= 3.1f)
            {
                muter = false;
                degr = -3.1f;
                Console.WriteLine("================================");
            }
            temp = flyObject(temp);
            return temp;
        }

        protected Matrix4 flyObject(Matrix4 temp)
        {
            curFly = curY;
            if (curFly <= minFly || mentokFly == false)
            {
                Console.WriteLine(curFly + " " + mentokFly);
                curFly += 0.005f;
                temp *= Matrix4.CreateTranslation(0, curFly, 0);
                mentokFly = false;
                if (curFly >= maxFly)
                {
                    mentokFly = true;
                }
            }
            else if (curFly >= maxFly || mentokFly == true)
            {
                curFly -= 0.005f;
                temp *= Matrix4.CreateTranslation(0, curFly, 0);
                if (curFly <= minFly)
                {
                    mentokFly = false;
                }
            }
            curY = curFly;
            return temp;
        }
    }
}
