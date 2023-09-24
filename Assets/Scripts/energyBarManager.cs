using UnityEngine;

public class energyBarManager : MonoBehaviour
{
    public float maxHeight = 5.0f;
    public float minHeight = 1.0f;

    public Color colorFirstThird = Color.green;
    public Color colorSecondThird = Color.yellow;
    public Color colorLastThird = Color.red;

    public float currentHeight = 0.0f;

    private bool isDecreasingHeight = false;

    private void Start()
    {
        //Set the bar's initial height to 1/3 of its max height
        currentHeight = maxHeight / 3.0f;
        UpdateBarHeight();
    }

    private void Update()
    {
        //Check if the "Z" key is held to decrease the height of the energy bar
        if (Input.GetKey(KeyCode.Z))
        {
            isDecreasingHeight = true;
        }
        else
        {
            isDecreasingHeight = false;
        }

        if (isDecreasingHeight)
        {
            DecreaseHeightOverTime();
        }

        //Change color based on the current height
        UpdateColor();
    }

    public void IncreaseHeight(float amount)
    {
        //Increase the height by the specified amount
        currentHeight = Mathf.Clamp(currentHeight + amount, minHeight, maxHeight);
        UpdateBarHeight();
    }

    private void DecreaseHeightOverTime()
    {
        //Gradually decrease the height over time with smooth animation
        float heightDecreaseSpeed = 2.0f;
        currentHeight = Mathf.Clamp(currentHeight - heightDecreaseSpeed * Time.deltaTime, minHeight, maxHeight);
        UpdateBarHeight();
    }

    private void UpdateColor()
    {
        //Determine the color based on thirds of the maximum height
        if (currentHeight <= minHeight + (maxHeight - minHeight) / 3)
        {
            ChangeColor(colorFirstThird);
        }
        else if (currentHeight <= minHeight + (maxHeight - minHeight) * 2 / 3)
        {
            ChangeColor(colorSecondThird);
        }
        else
        {
            ChangeColor(colorLastThird);
        }
    }

    private void ChangeColor(Color newColor)
    {
        //Change the color of the object
        GetComponent<Renderer>().material.color = newColor;
    }

    private void UpdateBarHeight()
    {
        //Update the bar's scale transform based on the current height
        float newYScale = currentHeight;
        float yPos = transform.position.y + (newYScale - transform.localScale.y) / 2;

        //Update the square's scale transform and position so it doesn't move as it gets bigger
        transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}