#version 330

out vec4 outputColor;

//in vec4 vertexColor;
in vec3 Normal;
in vec3 FragPos;

uniform vec3 ourColor;
uniform vec3 lightPos;


void main(){
	float ambientStrength = 0.3f;
	vec3 ambient = ambientStrength * vec3(1 ,1 ,1);

	vec3 norm = normalize(Normal);
//	vec3 lightDir = normalize(lightPos + FragPos);  
	vec3 lightDir = vec3(-0.5, 0, 0);
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * vec3(1,1,1);

	vec3 result = (ambient + diffuse) * ourColor;
	outputColor = vec4(result, 1.0f);
}
