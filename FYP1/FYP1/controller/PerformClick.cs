using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotiv;

namespace FYP1.controller
{
    class PerformClick
    {
        
        static System.IO.StreamWriter expLog = new System.IO.StreamWriter("FacialExpression.log");

        

        static Boolean enableLoger = false;

        static void engine_EmoEngineConnected(object sender, EmoEngineEventArgs e)
        {
            //Console.WriteLine("Emoengine connected");
        }

        static void engine_EmoEngineDisconnected(object sender, EmoEngineEventArgs e)
        {
            //Console.WriteLine("Emoengine disconnected");
        }

        static void engine_FacialExpressionEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
        {
            EmoState es = e.emoState;

            Single timeFromStart = es.GetTimeFromStart();

            EdkDll.IEE_FacialExpressionAlgo_t[] expAlgoList = { 
                                                      EdkDll.IEE_FacialExpressionAlgo_t.FE_WINK_LEFT, 
                                                      EdkDll.IEE_FacialExpressionAlgo_t.FE_WINK_RIGHT
                                                      };
            Boolean[] isExpActiveList = new Boolean[expAlgoList.Length];

            Boolean isLeftWink = es.FacialExpressionIsLeftWink();
            Boolean isRightWink = es.FacialExpressionIsRightWink();
            for (int i = 0; i < expAlgoList.Length; ++i)
            {
                isExpActiveList[i] = es.FacialExpressionIsActive(expAlgoList[i]);
            }

            //expLog.Write("{0},{1},",isLeftWink, isRightWink);
            //for (int i = 0; i < expAlgoList.Length; ++i)
            //{
            //    expLog.Write("{0},", isExpActiveList[i]);
            //}
            if (isLeftWink)
                Mouse.LeftClick();
            if (isRightWink)
                Mouse.RightClick();
                
            expLog.WriteLine("");
            expLog.Flush();
        }

        //static void keyHandler(ConsoleKey key)
        //{
        //    switch (key)
        //    {
        //        case ConsoleKey.F1:
        //            ulong action1 = (ulong)EdkDll.IEE_MentalCommandAction_t.MC_LEFT;
        //            ulong action2 = (ulong)EdkDll.IEE_MentalCommandAction_t.MC_RIGHT;
        //            ulong listAction = action1 | action2;
        //            EmoEngine.Instance.MentalCommandSetActiveActions(0, listAction);
        //            Console.WriteLine("Setting MentalCommand active actions for user");
        //            break;
        //        case ConsoleKey.F2:
        //            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL);
        //            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
        //            break;
        //        case ConsoleKey.F3:
        //            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_RIGHT);
        //            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
        //            break;
        //        case ConsoleKey.F4:
        //            EmoEngine.Instance.MentalCommandSetTrainingAction(0, EdkDll.IEE_MentalCommandAction_t.MC_LEFT);
        //            EmoEngine.Instance.MentalCommandSetTrainingControl(0, EdkDll.IEE_MentalCommandTrainingControl_t.MC_START);
        //            break;
        //        case ConsoleKey.F5:
        //            EmoEngine.Instance.MentalCommandSetActivationLevel(0, 2);
        //            Console.WriteLine("MentalCommand Activateion level set to {0}", EmoEngine.Instance.MentalCommandGetActivationLevel(0));
        //            break;
        //        case ConsoleKey.F6:
        //            Console.WriteLine("MentalCommand Activateion level is {0}", EmoEngine.Instance.MentalCommandGetActivationLevel(0));
        //            break;
        //        case ConsoleKey.F7:
        //            Console.WriteLine("Get the current overall skill rating: {0}", EmoEngine.Instance.MentalCommandGetOverallSkillRating(0));
        //            break;
        //        case ConsoleKey.F8:
        //            EmoEngine.Instance.FacialExpressionSetTrainingAction(0, EdkDll.IEE_FacialExpressionAlgo_t.FE_CLENCH);
        //            EmoEngine.Instance.FacialExpressionSetTrainingControl(0, EdkDll.IEE_FacialExpressionTrainingControl_t.FE_START);
        //            break;
        //        case ConsoleKey.F9:
        //            String version;
        //            UInt32 buildNum;
        //            EmoEngine.Instance.SoftwareGetVersion(out version, out buildNum);
        //            Console.WriteLine("Software Version: {0}, {1}", version, buildNum);
        //            break;
        //        case ConsoleKey.F10:
        //            enableLoger = !enableLoger;
        //            break;

        //        default:
        //            break;
        //    }
        //}

        public static void click()
        {
            EmoEngine engine = EmoEngine.Instance;

            engine.EmoEngineConnected += new EmoEngine.EmoEngineConnectedEventHandler(engine_EmoEngineConnected);
            engine.EmoEngineDisconnected +=new EmoEngine.EmoEngineDisconnectedEventHandler(engine_EmoEngineDisconnected);
            engine.FacialExpressionEmoStateUpdated +=new EmoEngine.FacialExpressionEmoStateUpdatedEventHandler(engine_FacialExpressionEmoStateUpdated);
            
            engine.Connect();
           
           // Console.WriteLine("===========================================================================");
           //Console.WriteLine("===========================================================================");

            //ConsoleKeyInfo cki = new ConsoleKeyInfo();
                try
                {
                    engine.ProcessEvents(3);
                }
                catch (EmoEngineException e)
                {
                    Console.WriteLine("{0}", e.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}", e.ToString());
                }
            engine.Disconnect();
        }
    }
}
