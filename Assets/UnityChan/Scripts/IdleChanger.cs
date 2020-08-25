using UnityEngine;
using System.Collections;

//
// ↑↓キーでループアニメーションを切り替えるスクリプト（ランダム切り替え付き）Ver.3
// 2014/04/03 N.Kobayashi
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]



public class IdleChanger : MonoBehaviour
{
	
	private Animator anim;						// Animatorへの参照
	public bool _random = true;				// ランダム判定スタートスイッチ
	public float _threshold = 0.5f;				// ランダム判定の閾値
	public float _interval = 10f;                // ランダム判定のインターバル
    int speedHash = Animator.StringToHash("Speed");
    int waitPosHash = Animator.StringToHash("waitPos");


    // Use this for initialization
    void Start ()
	{
		// 各参照の初期化
		anim = GetComponent<Animator> ();
		// ランダム判定用関数をスタートする
		StartCoroutine ("RandomChange");
	}
	
	// Update is called once per frame
	void  Update ()
	{
        
	}
    
	// ランダム判定用関数
	IEnumerator RandomChange ()
	{
		// 無限ループ開始
		while (true) {
			//ランダム判定スイッチオンの場合
        yield return new WaitForSeconds (_interval);

			if (_random) {
				// ランダムシードを取り出し、その大きさによってフラグ設定をする
				float _seed = Random.Range (0f, 1f);
                if(anim.GetFloat(waitPosHash) == 0f && anim.GetFloat(speedHash) == 0f) { 
				    if (_seed <= 0.33f) {
                        anim.Play("Idle01", 0);
				    } else if (_seed <= 0.66f) {
                        anim.Play("Idle02", 0);
                    } else if (_seed <= 1f) {
                        anim.Play("Idle03", 0);
                    } 
                } 
			}
		}
	}
}
