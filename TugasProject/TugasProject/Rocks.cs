using LearnOpenTK.Common;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasProject
{
    internal class Rocks: Asset3d
    {
        float time = 0;
        List<Asset3d> objectList = new List<Asset3d>();
        List<float> index_x = new List<float>();
        List<float> index_z = new List<float>();

        public Rocks() { }

        public void initObjects()
        {

            var rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.03f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.5f);
            index_z.Add(0.4f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.05f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.55f);
            index_z.Add(0.55f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.07f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.65f);
            index_z.Add(0.65f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.06f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.4f);
            index_z.Add(0.5f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.04f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.45f);
            index_z.Add(0.7f);


            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.05f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.4f);
            index_z.Add(0.8f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.08f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.55f);
            index_z.Add(0.85f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.05f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.5f);
            index_z.Add(1.0f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.02f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.45f);
            index_z.Add(0.9f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.04f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.55f);
            index_z.Add(1.1f);

            rock = new Asset3d();
            rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.02f, 0.03f);
            rock.setColor((0.8f, 0.8f, 0.8f));
            objectList.Add(rock);
            index_x.Add(0.5f);
            index_z.Add(1.0f);

            //Random rand = new Random();
            //float rad = 0;
            //for(int i = 0; i < 10; i++)
            //{
            //    rad = (rand.Next(1, 6) + 5) / 100;
            //    rock = new Asset3d();
            //    rock.createFilledCylinder(0.0f, 0.0f, 0.0f, 0.01f, rad);
            //    rock.setColor((0.8f, 0.8f, 0.8f));
            //    objectList.Add(rock);
            //}
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
            time += (float)args.Time * 10;

            Matrix4 temp = Matrix4.Identity;
            int index = 0;

            for(int i = 0; i < objectList.Count; i++)
            {
                if(time >= (5 * i) + 1 && time <= (i + 1) * 5)
                {
                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f * (time - 5 * i + 1) / 6));
                    temp = temp * Matrix4.CreateTranslation(index_x[i] + x, 0.09f + y, index_z[i] + z);
                    objectList[i].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                }else if(time > (i + 1) * 5)
                {
                    temp = Matrix4.Identity;
                    temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
                    temp = temp * Matrix4.CreateTranslation(index_x[i] + x, 0.09f + y, index_z[i] + z);
                    objectList[i].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                }
            }

            if(time > 55)
            {
                for (int i = 0; i < objectList.Count; i++)
                {
                    if (time >= (5 * (i + 10)) + 1 && time <= ((i + 10) + 1) * 5)
                    {
                        temp = Matrix4.Identity;
                        temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f * (time - 5 * (i + 10) + 1) / 6));
                        temp = temp * Matrix4.CreateTranslation(index_x[i] - 0.3f + x, 0.09f + y, index_z[i] + 0.5f + z);
                        objectList[i].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                    }
                    else if (time > ((i + 10) + 1) * 5)
                    {
                        temp = Matrix4.Identity;
                        temp = temp * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
                        temp = temp * Matrix4.CreateTranslation(index_x[i] - 0.3f + x, 0.09f + y, index_z[i] + 0.5f + z);
                        objectList[i].render(temp, scale, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                    }
                }
            }



        }
    }
}
