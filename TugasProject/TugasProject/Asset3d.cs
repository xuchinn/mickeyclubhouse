using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasProject
{
    internal class Asset3d
    {
        public List<Vector3> _vertices = new List<Vector3>();
        private List<uint> _indices = new List<uint>();

        private Vector3 color;

        int _vertexBufferObject;
        int _elementBufferObject;
        int _vertexArrayObject;
        Shader _shader;

        //Matrix4 _view;
        //Matrix4 _projection;
        Matrix4 model;

        public Vector3 _centerPosition = new Vector3(0, 0, 0);
        public List<Vector3> _euler = new List<Vector3>();

        public List<Vector3> _vertice_bezier = new List<Vector3>();

        public Asset3d(Vector3 color)
        {
            this.color = color;
            //sumbu X
            _euler.Add(new Vector3(1, 0, 0));
            //sumbu y
            _euler.Add(new Vector3(0, 1, 0));
            //sumbu z
            _euler.Add(new Vector3(0, 0, 1));
        }

        public Asset3d()
        {
            //sumbu X
            _euler.Add(new Vector3(1, 0, 0));
            //sumbu y
            _euler.Add(new Vector3(0, 1, 0));
            //sumbu z
            _euler.Add(new Vector3(0, 0, 1));
        }

        public void setColor(Vector3 color)
        {
            this.color = color;
        }

        public void load(String pathShader, int shaderChoice)
        {
            model = Matrix4.Identity;
            //Inisialisasi
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count * Vector3.SizeInBytes, _vertices.ToArray(),
                BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            
            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            ////0 -> referensi dari parameter 1
            //GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //0 -> referensi dari parameter 1
            GL.EnableVertexAttribArray(0);
            //Offset nya karena mulai dari 3 ya dibuat 3 dan dikasi sizeof float karena dihitungnya
            //dari index bytenya
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            if (_indices.Count != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Count * sizeof(uint)
                    , _indices.ToArray(), BufferUsageHint.StaticDraw);
            }

            if (shaderChoice == 0)
            {
                _shader = new Shader(pathShader + "shaderPolos.vert",
                pathShader + "shaderPolos.frag");
            }
            else if (shaderChoice == 1)
            {
                _shader = new Shader(pathShader + "shader.vert",
                pathShader + "shader.frag");
            }
            else if (shaderChoice == 2)
            {
                _shader = new Shader(pathShader + "shaderCone.vert",
                pathShader + "shaderCone.frag");
            }

            _shader.Use();

            //_view = Matrix4.CreateTranslation(0, 0, -3.0f);

            //_projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f),
            //    Size_x / (float)Size_y, 0.1f, 100.0f);
        }

        // Scaling buat scale on render
        public void render(Matrix4 temp, float scaling, Matrix4 camera_view, Matrix4 camera_projection)
        {
            _shader.Use();

            GL.BindVertexArray(_vertexArrayObject);
             /**Matrix4.CreateRotationY((float)MathHelper)**/;
            model = temp * Matrix4.CreateScale(scaling);
            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", camera_view);
            _shader.SetMatrix4("projection", camera_projection);


            //Uniforms
            _shader.SetVector3("ourColor", color);
            //var uniformData = GL.GetUniformLocation(_shader.Handle, "objColor");
            //GL.Uniform3(uniformData, color);
            //========
            if (_indices.Count != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, _indices.Count, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawArrays(PrimitiveType.LineStrip, 0, _vertices.Count);
            }
        }
        public void scale(float a)
        {
            model = model * Matrix4.CreateScale(a);
        }

        public void setModel(float x, float y, float z)
        {
            model += Matrix4.CreateTranslation(x, y, z);
        }

        public void createEllipsoid(float _x, float _y, float _z, float radiusX, float radiusY, float radiusZ, int sectorCount, int stackCount)
        {
            _centerPosition.X = _x;
            _centerPosition.Y = _y;
            _centerPosition.Z = _z;
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;

            for (int i = 0; i <= stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (float)Math.Cos(StackAngle);
                z = radiusZ * (float)Math.Sin(StackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y * (float)Math.Sin(sectorAngle);
                    temp_vector.Z = z;
                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }

        public void createEllipticParaboloid(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
        {
            _centerPosition.X = _x;
            _centerPosition.Y = _y;
            _centerPosition.Z = _z;
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi; u += pi / 1000)
            {
                for (float v = 0; v <= 4 / 3; v += pi / 1000)
                {
                    temp_vector.X = _x + (float)Math.Cos(u) * radiusX * v;
                    temp_vector.Y = _y + (float)Math.Sin(u) * radiusY * v;
                    temp_vector.Z = _z + v * v * radiusZ;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void createHemisphere(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
        {
            int sectorCount = 288;
            int stackCount = 96;

            _centerPosition.X = _x;
            _centerPosition.Y = _y;
            _centerPosition.Z = _z;
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;

            for (int i = 0; i <= stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (float)Math.Cos(StackAngle);
                z = radiusZ * (float)Math.Sin(StackAngle);

                for (int j = 0; j <= sectorCount / 2; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y * (float)Math.Sin(sectorAngle);
                    temp_vector.Z = z;
                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }

        public void createCone(float x, float y, float z, float lengthX, float lengthY, float lengthZ)
        {
            float _X = x;
            float _Y = y;
            float _Z = z;

            float _RadiusX = lengthX;
            float _RadiusY = lengthY;
            float _RadiusZ = lengthZ;
            Vector3 temp_vector = new Vector3();
            float _pi = 3.14159f;
            int count = 100;
            int temp_index = -1;
            float increament = 2 * _pi / count;
            for (float u = -_pi; u <= _pi + increament; u += increament)
            {
                for (float v = -_pi / 2; v <= 0; v += increament)
                {
                    temp_index++;
                    temp_vector.X = _X + _RadiusX * (float)Math.Cos(u) * v;
                    temp_vector.Y = _Y + _RadiusY * (float)Math.Sin(u) * v;
                    temp_vector.Z = _Z + _RadiusZ * v;
                    _vertices.Add(temp_vector);
                    if (u != -_pi)
                    {
                        if ((temp_index % count) + 1 < count)
                        {
                            _indices.Add(Convert.ToUInt32(temp_index));
                            _indices.Add(Convert.ToUInt32(temp_index - count));
                            _indices.Add(Convert.ToUInt32(temp_index - count + 1));
                        }
                        if (temp_index % count > 0)
                        {
                            _indices.Add(Convert.ToUInt32(temp_index));
                            _indices.Add(Convert.ToUInt32(temp_index - count));
                            _indices.Add(Convert.ToUInt32(temp_index - 1));
                        }
                    }
                }
                if (u == -_pi)
                {
                    count = _vertices.Count;
                }
            }
        }

        // Bezier
        public Vector3 getSegment(float Time)
        {
            Time = Math.Clamp(Time, 0, 1);
            float time = 1 - Time;
            Vector3 result =
            ((float)Math.Pow(time, 3) * _vertice_bezier[0])
            + (3 * time * time * Time * _vertice_bezier[1])
            + (3 * time * Time * Time * _vertice_bezier[2])
            + (Time * Time * Time * _vertice_bezier[3]);
            return result;
        }
        public void Bezier3d()
        {
            List<Vector3> segments = new List<Vector3>();
            float time;

            for (float i = 0; i < 1.0f; i += 0.01f)
            {

                time = i;
                segments.Add(getSegment(time));
            }

            setVertices(segments);

        }
        public void setVertices(List<Vector3> vertices)
        {
            _vertices = vertices;
        }
        public void AddCoordinates(float x1, float y1, float z1)
        {
            _vertice_bezier.Add(new Vector3(x1, y1, z1));
        }

        public void createTorus(float center_x, float center_y, float center_z, float r1, float r2)
        {
            _centerPosition.X = center_x;
            _centerPosition.Y = center_y;
            _centerPosition.Z = center_z;

            float pi = (float)Math.PI;
            Vector3 temp_vector;

            for (float u = 0; u <= 2 * pi; u += pi / 700)
            {
                for (float v = 0; v <= 2 * pi; v += pi / 700)
                {
                    temp_vector.X = center_x + (r1 + r2 * (float)Math.Cos(v)) * (float)Math.Cos(u);
                    temp_vector.Y = center_y + (r1 + r2 * (float)Math.Cos(v)) * (float)Math.Sin(u);
                    temp_vector.Z = center_z + r2 * (float)Math.Sin(v);
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void createHalfTorus(float center_x, float center_y, float center_z, float radx, float rady, float r2)
        {
            _centerPosition.X = center_x;
            _centerPosition.Y = center_y;
            _centerPosition.Z = center_z;

            float pi = (float)Math.PI;
            Vector3 temp_vector;

            for (float u = 0; u <= pi; u += pi / 700)
            {
                for (float v = 0; v <= 2 * pi; v += pi / 700)
                {
                    temp_vector.X = center_x + (radx + r2 * (float)Math.Cos(v)) * (float)Math.Cos(u);
                    temp_vector.Y = center_y + (rady + r2 * (float)Math.Cos(v)) * (float)Math.Sin(u);
                    temp_vector.Z = center_z + r2 * (float)Math.Sin(v);
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void createBoxVertices(float x, float y, float z, float length, float uk_x, float uk_y, float uk_z)
        {
            _centerPosition.X = x;
            _centerPosition.Y = y;
            _centerPosition.Z = z;

            //kalau x dibesarin jadi persegi panjang horizontal
            //kalau y dibesarin jadi persegi panjang vertical

            Vector3 temp_vector;

            float _x = uk_x;
            float _y = uk_y;
            float _z = uk_z;

            //TITIK 1
            temp_vector.X = x - length / _x;
            temp_vector.Y = y - length / _y;
            temp_vector.Z = z - length / _z;
            _vertices.Add(temp_vector);
            //TITIK 2
            temp_vector.X = x + length / _x;
            temp_vector.Y = y - length / _y;
            temp_vector.Z = z - length / _z;
            _vertices.Add(temp_vector);
            //TITIK 3
            temp_vector.X = x + length / _x;
            temp_vector.Y = y + length / _y;
            temp_vector.Z = z - length / _z;
            _vertices.Add(temp_vector);
            //TITIK 4
            temp_vector.X = x - length / _x;
            temp_vector.Y = y + length / _y;
            temp_vector.Z = z - length / _z;
            _vertices.Add(temp_vector);
            //TITIK 5
            temp_vector.X = x - length / _x;
            temp_vector.Y = y - length / _y;
            temp_vector.Z = z + length / _z;
            _vertices.Add(temp_vector);
            //TITIK 6
            temp_vector.X = x + length / _x;
            temp_vector.Y = y - length / _y;
            temp_vector.Z = z + length / _z;
            _vertices.Add(temp_vector);
            //TITIK 7
            temp_vector.X = x + length / _x;
            temp_vector.Y = y + length / _y;
            temp_vector.Z = z + length / _z;
            _vertices.Add(temp_vector);
            //TITIK 8
            temp_vector.X = x - length / _x;
            temp_vector.Y = y + length / _y;
            temp_vector.Z = z + length / _z;
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {

                 //front
                0, 7, 3,
                0, 4, 7,
                //back
                1, 2, 6,
                6, 5, 1,
                //left
                0, 2, 1,
                0, 3, 2,
                //right
                4, 5, 6,
                6, 7, 4,
                //top
                2, 3, 6,
                6, 3, 7,
                //bottom
                0, 1, 5,
                0, 5, 4
            };
        }

        public void createCylinder(float x, float y, float z, float length, float tinggi)
        {
            float _X = x;
            float _Y = y;
            float _Z = z;
            float height = tinggi;
            float _Radius = length;
            Vector3 temp_vector = new Vector3();
            float _pi = 3.14159f;

            int count = 100;
            int temp_index = -1;
            float increament = _pi / count;


            for (float u = 0; u <= 2 * _pi + increament; u += increament)
            {
                for (float v = 0; v <= height + increament; v += increament)
                {
                    temp_index++;
                    temp_vector.X = _X + _Radius * (float)Math.Cos(u);
                    temp_vector.Y = _Y + _Radius * (float)Math.Sin(u);
                    temp_vector.Z = _Z + _Radius * v;
                    _vertices.Add(temp_vector);
                    if (u != 0)
                    {
                        if ((temp_index % count) + 1 < count)
                        {
                            _indices.Add(Convert.ToUInt32(temp_index));
                            _indices.Add(Convert.ToUInt32(temp_index - count));
                            _indices.Add(Convert.ToUInt32(temp_index - count + 1));
                        }
                        if (temp_index % count > 0)
                        {
                            _indices.Add(Convert.ToUInt32(temp_index));
                            _indices.Add(Convert.ToUInt32(temp_index - count));
                            _indices.Add(Convert.ToUInt32(temp_index - 1));
                        }
                    }
                }
                if (u == 0)
                {
                    count = _vertices.Count;
                }
            }
        }

        public void createFilledCylinder(float x_, float y_, float z_, float height, float radius)
        {
            int sectorCount = 72;
            int stackCount = 24;
            Vector3 temp_vector;
            float sectorAngle, x, y, z;
            int stackCount2 = stackCount;

            for (int j = 0; j <= sectorCount; ++j)
            {
                _vertices.Add(new Vector3(x_, y_ - height / 2, z_));
            }

            for (int j = 0; j <= sectorCount; ++j)
            {
                sectorAngle = j * 2 * (float)Math.PI / sectorCount;

                temp_vector.X = x_ + radius * (float)Math.Cos(sectorAngle);
                temp_vector.Y = y_ - height / 2;
                temp_vector.Z = z_ + radius * (float)Math.Sin(sectorAngle);

                _vertices.Add(temp_vector);
            }
            stackCount2 += 2;

            for (int i = 0; i <= stackCount; ++i)
            {
                x = z = radius;
                y = height * i / stackCount - height / 2;

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * 2 * (float)Math.PI / sectorCount;

                    temp_vector.X = x_ + x * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y_ + y;
                    temp_vector.Z = z_ + z * (float)Math.Sin(sectorAngle);

                    _vertices.Add(temp_vector);
                }
            }

            for (int j = 0; j <= sectorCount; ++j)
            {
                sectorAngle = j * 2 * (float)Math.PI / sectorCount;

                temp_vector.X = x_ + radius * (float)Math.Cos(sectorAngle);
                temp_vector.Y = y_ + height / 2;
                temp_vector.Z = z_ + radius * (float)Math.Sin(sectorAngle);

                _vertices.Add(temp_vector);
            }

            for (int j = 0; j <= sectorCount; ++j)
            {
                _vertices.Add(new Vector3(x_, y_ + height / 2, z_));
            }

            stackCount2 += 2;

            uint k1, k2;
            for (int i = 0; i < stackCount2; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);

                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0 && i != 1)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);
                    }

                    if (i != stackCount2 - 1 && i != stackCount2 - 2)
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }

        //Rotate Ko Denzel
        //public void rotate(Vector3 pivot, Vector3 vector, float angle)
        //{
        //    var radAngle = MathHelper.DegreesToRadians(angle);

        //    var arbRotationMatrix = new Matrix4
        //        (
        //        new Vector4((float)(Math.Cos(radAngle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) + vector.Z * Math.Sin(radAngle)), (float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.Y * Math.Sin(radAngle)), 0),
        //        new Vector4((float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) - vector.Z * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.X * Math.Sin(radAngle)), 0),
        //        new Vector4((float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.Y * Math.Sin(radAngle)), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.X * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(radAngle))), 0),
        //        Vector4.UnitW
        //        );

        //    model *= Matrix4.CreateTranslation(-pivot);
        //    model *= arbRotationMatrix;
        //    model *= Matrix4.CreateTranslation(pivot);

        //    for (int i = 0; i < 3; i++)
        //    {
        //        _euler[i] = Vector3.Normalize(getRotationResult(pivot, vector, radAngle, _euler[i], true));
        //    }

        //    rotationCenter = getRotationResult(pivot, vector, radAngle, rotationCenter);
        //    objectCenter = getRotationResult(pivot, vector, radAngle, objectCenter);

        //    foreach (var i in child)
        //    {
        //        i.rotate(pivot, vector, angle);
        //    }
        //}

        public void Rotate(Vector3 pivot, Vector3 vector, float angle)
        {
            //pivot -> mau rotate di titik mana
            //vector -> mau rotate di sumbu apa? (x,y,z)
            //angle -> rotatenya berapa derajat?

            angle = MathHelper.DegreesToRadians(angle);

            //mulai ngerotasi
            for (int i = 0; i < _vertices.Count; i++)
            {
                _vertices[i] = getRotationResult(pivot, vector, angle, _vertices[i]);
            }
            //rotate the euler direction
            for (int i = 0; i < 3; i++)
            {
                _euler[i] = getRotationResult(pivot, vector, angle, _euler[i], true);

                //NORMALIZE
                //LANGKAH - LANGKAH
                //length = akar(x^2+y^2+z^2)
                float length = (float)Math.Pow(Math.Pow(_euler[i].X, 2.0f) + Math.Pow(_euler[i].Y, 2.0f) + Math.Pow(_euler[i].Z, 2.0f), 0.5f);
                Vector3 temporary = new Vector3(0, 0, 0);
                temporary.X = _euler[i].X / length;
                temporary.Y = _euler[i].Y / length;
                temporary.Z = _euler[i].Z / length;
                _euler[i] = temporary;
            }
            _centerPosition = getRotationResult(pivot, vector, angle, _centerPosition);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count * Vector3.SizeInBytes,
                _vertices.ToArray(), BufferUsageHint.StaticDraw);
        }

        Vector3 getRotationResult(Vector3 pivot, Vector3 vector, float angle, Vector3 point, bool isEuler = false)
        {
            Vector3 temp, newPosition;
            if (isEuler)
            {
                temp = point;
            }
            else
            {
                temp = point - pivot;
            }

            newPosition.X =
                (float)temp.X * (float)(Math.Cos(angle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(angle))) +
                (float)temp.Y * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) - vector.Z * Math.Sin(angle)) +
                (float)temp.Z * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) + vector.Y * Math.Sin(angle));
            newPosition.Y =
                (float)temp.X * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) + vector.Z * Math.Sin(angle)) +
                (float)temp.Y * (float)(Math.Cos(angle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(angle))) +
                (float)temp.Z * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) - vector.X * Math.Sin(angle));
            newPosition.Z =
                (float)temp.X * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) - vector.Y * Math.Sin(angle)) +
                (float)temp.Y * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) + vector.X * Math.Sin(angle)) +
                (float)temp.Z * (float)(Math.Cos(angle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(angle)));

            if (isEuler)
            {
                temp = newPosition;
            }
            else
            {
                temp = newPosition + pivot;
            }
            return temp;
        }

        public void resetEuler()
        {
            _euler[0] = new Vector3(1, 0, 0);
            _euler[1] = new Vector3(0, 1, 0);
            _euler[2] = new Vector3(0, 0, 1);
        }
    }
}