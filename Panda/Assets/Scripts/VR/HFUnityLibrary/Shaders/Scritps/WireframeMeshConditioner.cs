using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshFilter))]
public class WireframeMeshConditioner : MonoBehaviour 
{
	private MeshFilter mf;

	void Start () 
	{
		mf = GetComponent<MeshFilter> ();
		AddBarycentricCoordinates ();
	}

	private void AddBarycentricCoordinates()
	{
		List<Vector2> newUVs = new List<Vector2>();
		List<Vector2> barycentricCoordinates = new List<Vector2>();
		List<Vector3> newPositions = new List<Vector3>();
		List<Vector3> newNormals = new List<Vector3>();
		List<int> newTriangles = new List<int>();
		int iterator = 0;
		for (int i = 0; i < mf.mesh.triangles.Length/3; i++) 
		{
			newTriangles.Add(iterator);
			int index = mf.mesh.triangles [iterator];
			newPositions.Add(mf.mesh.vertices[index]);
			newUVs.Add(mf.mesh.uv[index]);
			newNormals.Add(mf.mesh.normals[index]);
			barycentricCoordinates.Add(new Vector2(0.0f, 0.0f));
			iterator++;

			newTriangles.Add(iterator);
			index = mf.mesh.triangles [iterator];
			newPositions.Add(mf.mesh.vertices[index]);
			newUVs.Add(mf.mesh.uv[index]);
			newNormals.Add(mf.mesh.normals[index]);
			barycentricCoordinates.Add(new Vector2(0.0f, 1.0f));
			iterator++;

			newTriangles.Add(iterator);
			index = mf.mesh.triangles [iterator];
			newPositions.Add(mf.mesh.vertices[index]);
			newUVs.Add(mf.mesh.uv[index]);
			newNormals.Add(mf.mesh.normals[index]);
			barycentricCoordinates.Add(new Vector2(1.0f, 1.0f));
			iterator++;
		}
		mf.mesh.SetVertices(newPositions);
		mf.mesh.SetTriangles(newTriangles, 0);
		mf.mesh.SetNormals(newNormals);
		mf.mesh.SetUVs(0, newUVs);
		mf.mesh.SetUVs(1, barycentricCoordinates);
	}
}
