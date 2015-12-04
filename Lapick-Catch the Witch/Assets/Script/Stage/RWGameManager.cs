using UnityEngine;
using System.Collections;

public class RWGameManager : MonoBehaviour {

    protected int blockCount;
    protected bool isPause;
    protected int levelUpBlockCount;
    protected int currentLevelUpBlockCountTotal;
    protected float baseScrollSpeed = 3.0f;
    protected float maxScrollSpeed = 6.0f;
    protected int blockColMinSize = 2;
    protected int blockColMaxSize = 5;
    protected float blockSpaceMinSizeX = 2f;
    protected float blockSpaceMaxSizeX = 2.6f;
    protected float blockSpaceMinSizeY = 0f;
    protected float blockSpaceMaxSizeY = 0.4f;
    protected float currentScrollSpeed;
    protected int currentblockColMinSize;
    protected int currentblockColMaxSize;
    protected float currentblockSpaceMinSizeX;
    protected float currentblockSpaceMaxSizeX;
    protected float currentblockSpaceMinSizeY;
    protected float currentblockSpaceMaxSizeY;

    void Update()
    {
        if (isPause == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void StageLevelInitialize()
    {
        currentLevelUpBlockCountTotal = 0;
        ScrollSpeedInialize();

        currentScrollSpeed = baseScrollSpeed;

        currentblockColMinSize = 3;
        currentblockColMaxSize = 5;

        currentblockSpaceMinSizeX = 0.7f;
        currentblockSpaceMaxSizeX = 1f;

        currentblockSpaceMinSizeY = blockSpaceMinSizeY;
        currentblockSpaceMaxSizeY = blockSpaceMaxSizeY;

        BlockColMinSizeX(currentblockColMinSize);
        BlockColMaxSizeX(currentblockColMaxSize);
        BlockSpaceMinSizeX(currentblockSpaceMinSizeX);
        BlockSpaceMaxSizeX(currentblockSpaceMaxSizeX);
        BlockSpaceMinSizeY(currentblockSpaceMinSizeY);
        BlockSpaceMaxSizeY(currentblockSpaceMaxSizeY);

        SendMessage("BlockNumberinitializeMessanger");
    }

    protected void LevelUp()
    {
        if (currentScrollSpeed < maxScrollSpeed)
            currentScrollSpeed *= 1.04f;
        if (currentblockColMinSize > blockColMinSize)
            currentblockColMinSize -= 1;
        if (currentblockSpaceMinSizeX < blockSpaceMinSizeX)
            currentblockSpaceMinSizeX *= 1.05f;
        if (currentblockSpaceMaxSizeX < blockSpaceMaxSizeX)
            currentblockSpaceMaxSizeX *= 1.05f;

        ScrollSpeedRefreshDelivery(currentScrollSpeed);
        BlockColMinSizeX(currentblockColMinSize);
        BlockSpaceMinSizeX(currentblockSpaceMinSizeX);
        BlockSpaceMaxSizeX(currentblockSpaceMaxSizeX);
    }

    void RandomLevelUpBlockCount()
    {
        levelUpBlockCount = (int)Random.RandomRange(1.0f, 4.0f);
        currentLevelUpBlockCountTotal += levelUpBlockCount;
    }

    public void BlockCountRise()
    {
        blockCount++;
        SendMessage("BlockCounterRefreshDelivery", blockCount.ToString());
        if (blockCount >= currentLevelUpBlockCountTotal)
        {
            LevelUp();
            RandomLevelUpBlockCount();
        }
    }

    public void BlockCountInitialize()
    {
        blockCount = 0;
        SendMessage("BlockCounterRefreshDelivery", blockCount.ToString());
    }

    public void CurrentGameBlockCountTotal()
    {
        SendMessage("CurrentGameBlockCountTotalDelivery", blockCount);

        SendMessage("BestGameBlockCountTotal", blockCount);
    }

    public void PauseOn()
    {
        isPause = true;
    }

    public void PauseOff()
    {
        isPause = false;
    }

    void ScrollSpeedInialize()
    {
        SendMessage("ScrollSpeedRefresh", baseScrollSpeed);
        currentScrollSpeed = baseScrollSpeed;
    }

    protected void ScrollSpeedRefreshDelivery(float nScrollSpeed)
    {
        SendMessage("ScrollSpeedRefresh", nScrollSpeed);
    }

    protected void BlockColMinSizeX(int nMinSize)
    {
        SendMessage("PresentBlockColMinSizeXMessenger", nMinSize.ToString());
    }

    protected void BlockColMaxSizeX(int nMaxSize)
    {
        SendMessage("PresentBlockColMaxSizeXMessenger", nMaxSize.ToString());
    }

    protected void BlockSpaceMinSizeX(float nMinSize)
    {
        SendMessage("PresentBlockSpaceMinSizeXMessenger", nMinSize.ToString());
    }

    protected void BlockSpaceMaxSizeX(float nMaxSize)
    {
        SendMessage("PresentBlockSpaceMaxSizeXMessenger", nMaxSize.ToString());
    }

    protected void BlockSpaceMinSizeY(float nMinSize)
    {
        SendMessage("PresentBlockSpaceMinSizeYMessenger", nMinSize.ToString());
    }

    protected void BlockSpaceMaxSizeY(float nMaxSize)
    {
        SendMessage("PresentBlockSpaceMaxSizeYMessenger", nMaxSize.ToString());
    }
}
