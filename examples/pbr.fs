#version 330

#define PI 3.1415926538

// Eye-space.
in vec3 fPos;
in vec3 fNormal;
in vec2 fTexCoord;
in vec3 fTangent;
in vec3 fBitangent;

uniform mat3 uNormalMatrix;

uniform struct Material {
    vec3 base_color;
    float metallic;
    float perceptual_roughness;
    float reflectance;
    
    bool use_base_color_map;
    sampler2D base_color_map;
    
    bool use_metallic_roughness_map;
    sampler2D metallic_roughness_map;
    
    bool use_normal_map;
    sampler2D normal_map;
    
    bool use_emissive_map;
    sampler2D emissive_map;
    
    bool use_occlusion_map;
    sampler2D occlusion_map;
} material;

uniform samplerCube environment_map;
uniform bool use_environment_map;

struct Light {
    // Eye-space.
    vec3 direction;
    vec3 color;
};
const int MAX_LIGHTS = 5;
uniform Light lights[ MAX_LIGHTS ];

uniform int num_lights;

uniform int num_samples_diffuse;
uniform int num_samples_specular;

uniform float uTime;

// gl_FragColor is old-fashioned, but it's what WebGL 1 uses.
// From: https://stackoverflow.com/questions/9222217/how-does-the-fragment-shader-know-what-variable-to-use-for-the-color-of-a-pixel
layout(location = 0) out vec4 FragColor;

// Your code goes here.

// Returns a rotation matrix that applies the rotation given by the axis and angle.
mat3 rotation_matrix_from_axis_sin_cos_angle( vec3 axis, float sin_angle, float cos_angle ) {
    float u1 = axis.x;
    float u2 = axis.y;
    float u3 = axis.z;
    
    mat3 U = transpose(mat3(
        u1*u1, u1*u2, u1*u3,
        u2*u1, u2*u2, u2*u3,
        u3*u1, u3*u2, u3*u3
    ));
    mat3 S = transpose(mat3(
        0, -u3, u2,
        u3,  0, -u1,
        -u2,  u1, 0
    ));
    mat3 result = U + cos_angle * (mat3(1.0) - U) + sin_angle * S;
    return result;
}
mat3 rotation_matrix_from_axis_angle( vec3 axis, float angle ) {
    return rotation_matrix_from_axis_sin_cos_angle( axis, sin(angle), cos(angle) );
}

void main()
{
    // Your code goes here.
    
    FragColor = vec4( 1.0, 0.0, 1.0, 1.0 );
}
