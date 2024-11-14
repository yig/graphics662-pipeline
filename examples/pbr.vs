#version 330

uniform mat4 uProjectionMatrix;
uniform mat4 uViewMatrix;
uniform mat3 uNormalMatrix;

uniform int num_samples;

in vec3 vPos;
in vec3 vNormal;
in vec2 vTexCoord;
in vec3 vTangent;
in vec3 vBitangent;

out vec3 fPos;
out vec3 fNormal;
out vec2 fTexCoord;
out vec3 fTangent;
out vec3 fBitangent;

void main()
{
    // Your code goes here.
    
    // OpenGL requires that we put something for gl_Position.
    // This is wrong but will at least compile.
    gl_Position = vec4( 1.0, 1.0, 1.0, 1.0 );
}
